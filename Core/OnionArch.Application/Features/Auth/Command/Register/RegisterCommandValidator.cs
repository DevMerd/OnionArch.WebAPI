﻿using FluentValidation;

namespace OnionArch.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("İsim Soyisim");

            RuleFor(x => x.Email)
               .NotEmpty()
               .MaximumLength(60)
               .EmailAddress()
               .MinimumLength(8)
               .WithName("E-posta Adresi");

            RuleFor(x => x.Password)
               .NotEmpty()
               .MinimumLength(6)
               .WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
               .NotEmpty()
               .MinimumLength(6)
               .WithName("Parola Tekrar");
        }
    }
}