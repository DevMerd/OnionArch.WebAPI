using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionArch.Application.Bases;
using OnionArch.Application.Features.Auth.Rules;
using OnionArch.Application.Interfaces.AutoMapper;
using OnionArch.Application.Interfaces.Tokens;
using OnionArch.Application.Interfaces.UnitOfWorks;
using OnionArch.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnionArch.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly AuthRules _authRules;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(IMapper mapper, AuthRules authRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await _userManager.FindByEmailAsync(email);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            await _authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccesToken = await _tokenService.CreateToken(user, roles);
            string newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccesToken),
                RefreshToken = newRefreshToken
            };
        }
    }
}