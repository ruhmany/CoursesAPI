using Core.Entities;
using MediatR;

namespace Application.Commands.InstructorCommands
{
    public class AddInstructorCommand : IRequest<Instructor>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
    }
}
