using Application.Commands.CourseCommands;
using AutoMapper;
using Core.Entities;
using RahmanyCourses.Models;

namespace RahmanyCourses.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseModel>();
            CreateMap<CourseModel, AddCourseCommand>();
        }
    }
}
