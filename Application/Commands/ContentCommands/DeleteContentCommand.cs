using MediatR;
using RahmanyCourses.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Commands.ContentCommands
{
    public class DeleteContentCommand : IRequest<DeleteContentModel>
    {
        public int ContentId { get; set; }
        public int UserID { get; set; }
    }
}
