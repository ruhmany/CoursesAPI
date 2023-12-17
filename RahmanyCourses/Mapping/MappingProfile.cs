using Application.Commands.ContentCommands;
using Application.Commands.CourseCommands;
using Application.Commands.UserCommands;
using AutoMapper;
using Core.Entities;
using RahmanyCourses.DTO;
using RahmanyCourses.Models;

namespace RahmanyCourses.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseModel>();
            CreateMap<CourseModel, AddCourseCommand>();
            CreateMap<AddContentDTO, AddContentToCourseCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<RateCourseDTO, RateCourseCommand>();
        }
    }
}
