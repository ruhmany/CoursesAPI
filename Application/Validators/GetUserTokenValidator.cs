using System;
using System.Collections.Generic;
using RahmanyCourses.Application.Commands.UserCommands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RahmanyCourses.Application.Validators
{
    public class GetUserTokenValidator : AbstractValidator<GetUserTokenCommand>
    {
        public GetUserTokenValidator()
        {
            RuleFor(x=> x.UsernameOrEmail).NotEmpty()
                .NotNull()
                .WithMessage("Password Mustn't Be Null Or Empty")
                .EmailAddress().WithMessage("Invalide Email Format");

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("Password Mustn't Be Null Or Empty");

        }
    }
}
