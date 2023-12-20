using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Commands.CourseCommands
{
    public class AddCourseCommand : IRequest<CourseReturnModel>
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public int InstructorID { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
    }
}
