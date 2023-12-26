using FluentValidation;
using RahmanyCourses.Application.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Validators
{
    public class AddUserCommandValidation : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidation()
        {
            RuleFor(auc => auc.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("Username Mustn't Be Null Or Empty");
            RuleFor(auc => auc.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Username Mustn't Be Null Or Empty")
                .EmailAddress().WithMessage("Invalide Email Format");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("Password must not be empty");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("ConfirmPassword must not be empty");
            RuleFor(x => x)
                .Must(x => x.Password == x.ConfirmPassword)
                .WithMessage("Password and Confirm Password Must Be Same");
        }
    }
}
