using Application.Models;
using Core.Entities;
using MediatR;

namespace Application.Commands.CourseCommands
{
    public class EnrollInCourseCommand : IRequest<EnrollmentReturnModel>
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }        
    }
}
