using Application.Queries.EnrollmentQueries;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.EnrollmentHandlers.QueriesHandlers
{
    public class GetEnrollmentByStudentIdHandler : IRequestHandler<GetEnrollmentsByStudentIdQuery, IEnumerable<Enrollment>>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetEnrollmentByStudentIdHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> Handle(GetEnrollmentsByStudentIdQuery request, CancellationToken cancellationToken)
        {
            return await _enrollmentRepository.GetEnrollmentsByStudentId(request.StudentId);
        }
    }
}
