using FluentValidation;

namespace OnionArch.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(e => e.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}