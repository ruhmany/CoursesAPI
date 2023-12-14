using Application.Commands.CourseCategoryCommands;
using Application.Commands.CourseCommands;
using Application.Commands.UserCommands;
using Application.Commands.UserProfileCommands;
using Application.Models;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserCommand, User>();
            CreateMap<User, AuthModel>();
            CreateMap<AddUserProfileCommand, UserProfile>();
            CreateMap<AddCourseCommand, Course>();
            CreateMap<AddCourseCategoryCommand, CourseCategory>();
        }
    }
}
