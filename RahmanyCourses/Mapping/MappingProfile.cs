using RahmanyCourses.Application.Commands.ContentCommands;
using RahmanyCourses.Application.Commands.CourseCommands;
using RahmanyCourses.Application.Commands.UserCommands;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Persentation.Models;
using RahmanyCourses.Persentation.DTO;

namespace RahmanyCourses.Persentation.Mapping
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
