using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using MediatR;

namespace RahmanyCourses.Application.Commands.CourseCommands
{
    public class EnrollInCourseCommand : IRequest<EnrollmentReturnModel>
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }        
    }
}
