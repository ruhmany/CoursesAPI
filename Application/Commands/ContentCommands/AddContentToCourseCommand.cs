using RahmanyCourses.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using RahmanyCourses.Application.Models;

namespace RahmanyCourses.Application.Commands.ContentCommands
{
    public class AddContentToCourseCommand : IRequest<ContentReturnModel>
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public ContentType Type { get; set; }
        public IFormFile Content { get; set; }
        public int OrderInCourse { get; set; }
        public int CourseOwnerID { get; set; }
    }
}
