using Core.Entities;
using MediatR;

namespace Application.Commands.InstructorCommands
{
    public class UpdateInstructorCommand : IRequest<Instructor>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
    }
}
