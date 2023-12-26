using MediatR;
using Microsoft.AspNetCore.Http;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Enums;

namespace RahmanyCourses.Application.Commands.ContentCommands
{
    public class UpdateContentCommand : IRequest<ContentReturnModel>
    {
        public int CourseID { get; set; }
        public int CourseOwnerID { get; set; }
        public int ContentID { get; set; }
        public string Title { get; set; }
        public IFormFile Content { get; set; }
    }
}
