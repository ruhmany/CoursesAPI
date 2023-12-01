using Core.Entities;
using MediatR;

namespace Application.Commands.EnrollmentCommands
{
    public class AddEnrollmentCommand : IRequest<Enrollment>
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
    }
}
