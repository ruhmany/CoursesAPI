using AutoMapper;
using Core.Entities;
using RahmanyCourses.Models;

namespace RahmanyCourses.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Instructor, InstructorDTO>();
            CreateMap<InstructorDTO, Instructor>();
            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>();
        }
    }
}
