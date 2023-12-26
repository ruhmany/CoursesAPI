using RahmanyCourses.Application.Commands.ContentCommands;
using RahmanyCourses.Application.Commands.CourseCategoryCommands;
using RahmanyCourses.Application.Commands.CourseCommands;
using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Commands.UserProfileCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Mapping
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
            CreateMap<AddContentToCourseCommand, Content>();
            CreateMap<Course, CourseReturnModel>();
        }
    }
}
