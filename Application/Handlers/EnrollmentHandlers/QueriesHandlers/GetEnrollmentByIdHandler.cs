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
    public class GetEnrollmentByIdHandler : IRequestHandler<GetEnrollmentByIdQuery, Enrollment>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetEnrollmentByIdHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Enrollment> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _enrollmentRepository.GetEnrollmentByID(request.Id);
        }
    }
}
