using MediatR;
using RahmanyCourses.Application.Models;

namespace RahmanyCourses.Application.Commands.CourseCommands
{
    public class DeleteCourseCommand : IRequest<DeleteCourseResult>
    {
        public int CourseID { get; set; }
        public int UserID { get; set; }
    }
}
