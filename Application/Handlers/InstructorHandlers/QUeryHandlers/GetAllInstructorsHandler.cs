using Application.Queries.InstructorQueries;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.InstructorHandlers.QUeryHandlers
{
    public class GetAllInstructorsHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<Instructor>>
    {
        private readonly IInstructorRepository _repository;

        public GetAllInstructorsHandler(IInstructorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Instructor>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllInstructors();
        }
    }
}
