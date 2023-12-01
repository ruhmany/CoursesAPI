using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.EnrollmentQueries
{
    public class GetEnrollmentsByStudentIdQuery : IRequest<IEnumerable<Enrollment>>
    {
        public int StudentId { get; set; }
    }
}
