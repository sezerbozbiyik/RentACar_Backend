using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).Must(NotStartZero).WithMessage("Password 0 ile başlayamaz.");
            RuleFor(u => u.Password).MinimumLength(6);
        }

        private bool NotStartZero(string arg)
        {
            return !arg.StartsWith("0");
        }
    }
}
