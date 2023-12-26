using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application
{
    public static class ApplicationDependancyInjection
    {
        public static IServiceCollection InjectApplicationValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AddUserCommand>, AddUserCommandValidation>();
            return services;
        }
    }
}
