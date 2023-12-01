using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CourseCommands
{
    public class DeleteCourseCommand : IRequest<Course>
    {
        public int Id { get; set; }

    }
}
