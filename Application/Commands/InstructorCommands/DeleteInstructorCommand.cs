using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.InstructorCommands
{
    public class DeleteInstructorCommand : IRequest<Instructor>
    {
        public int Id { get; set; }

    }
}
