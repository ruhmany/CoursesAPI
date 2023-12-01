using Application.Commands.CourseCommands;
using Application.Commands.EnrollmentCommands;
using Application.Commands.InstructorCommands;
using Application.Commands.StudentCommands;
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
            CreateMap<AddCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
            CreateMap<AddEnrollmentCommand, Enrollment>();
            CreateMap<UpdateEnrollmentCommand, Enrollment>();
            CreateMap<AddInstructorCommand, Instructor>();
            CreateMap<UpdateInstructorCommand, Instructor>();
            CreateMap<AddStudentCommand, Student>();
            CreateMap<UpdateStudentCommand, Student>();
        }
    }
}
