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
    public class GetInstructorByIdHandler : IRequestHandler<GetinstructorByIDQuery, Instructor>
    {
        private readonly IInstructorRepository _repository;

        public GetInstructorByIdHandler(IInstructorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Instructor> Handle(GetinstructorByIDQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetInstructorByID(request.Id);
        }
    }
}
