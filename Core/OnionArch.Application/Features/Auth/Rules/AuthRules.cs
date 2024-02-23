using OnionArch.Application.Bases;
using OnionArch.Application.Features.Auth.Exceptions;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}
