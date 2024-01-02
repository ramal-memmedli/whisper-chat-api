using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.Business.DTOs.Account;

namespace Whisper.Business.Validators.Account
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(rdto => rdto.Username).NotNull().NotEmpty().MinimumLength(6).MaximumLength(64);
            RuleFor(rdto => rdto.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(64);
            RuleFor(rdto => rdto.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
