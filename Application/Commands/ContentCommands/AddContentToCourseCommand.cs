using Application.Models;
using Core.Entities;
using Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ContentCommands
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
