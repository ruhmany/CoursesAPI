using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.StudentQueries
{
    public class GetStudentByIDQuery : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
