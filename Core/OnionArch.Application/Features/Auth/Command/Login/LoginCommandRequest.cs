using MediatR;
using System.ComponentModel;

namespace OnionArch.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("admin@gmail.com")]
        public string Email { get; set; }

        [DefaultValue("admin123")]
        public string Password { get; set; }
    }
}