using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whisper.Business.DTOs.Account;

namespace Whisper.Business.Validators.Account
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator() 
        { 
            RuleFor(p => p.Username).NotNull().NotEmpty().MinimumLength(6).MaximumLength(64);
            RuleFor(ldto => ldto.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(64);
        }
    }
}
