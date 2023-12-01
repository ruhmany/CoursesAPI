using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.StudentCommands
{
    public class DeleteStudentCommand : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
