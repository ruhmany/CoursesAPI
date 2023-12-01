using Core.Entities;
using MediatR;

namespace Application.Commands.EnrollmentCommands
{
    public class DeleteEnrollmentCommand : IRequest<Enrollment>
    {
        public int Id { get; set; }
    }
}
