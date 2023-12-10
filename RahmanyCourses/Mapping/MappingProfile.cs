using AutoMapper;
using Core.Entities;
using RahmanyCourses.Models;
using RahmanyCourses.Response;

namespace RahmanyCourses.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
