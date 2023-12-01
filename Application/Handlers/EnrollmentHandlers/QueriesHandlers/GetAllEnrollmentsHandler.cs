using Application.Queries.CourseQueries;
using Application.Queries.EnrollmentQueries;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.EnrollmentHandlers.QueriesHandlers
{
    public class GetAllEnrollmentsHandler : IRequestHandler<GetAllEnrollmentQuery, IEnumerable<Enrollment>>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetAllEnrollmentsHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> Handle(GetAllEnrollmentQuery request, CancellationToken cancellationToken)
        {
            return await _enrollmentRepository.GetAllEnrollments();
        }
    }
}
