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
                .WithMessage("Username can't be empty")
                .NotNull()
                .WithMessage("Username can't be null")
                .MaximumLength(80)
                .WithMessage("length must be less than 80 char")
                .MinimumLength(8)
                .WithMessage("Username must be more than 8 char");
            RuleFor(auc => auc.Email)
                .NotEmpty()
                .WithMessage("E-mail can't be empty")
                .NotNull()
                .WithMessage("E-mail Mustn't Be Null")
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
