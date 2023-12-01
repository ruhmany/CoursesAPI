using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CourseCommands
{
    public class AddCourseCommand : IRequest<Course>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EnrollmentCapacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int InstructorID { get; set; }
    }
}
