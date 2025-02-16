using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Validators;

namespace RahmanyCourses.Application
{
    public static class ApplicationDependancyInjection
    {
        public static IServiceCollection InjectApplicationValidators(this IServiceCollection services)
        {
            return services.AddScoped<IValidator<AddUserCommand>, AddUserCommandValidation>()
                .AddScoped<IValidator<GetUserTokenCommand>, GetUserTokenValidator>();
        }
    }
}
