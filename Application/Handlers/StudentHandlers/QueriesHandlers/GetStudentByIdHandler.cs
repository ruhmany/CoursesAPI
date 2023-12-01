using Application.Queries.StudentQueries;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.StudentHandlers.QueriesHandlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIDQuery, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentByID(request.Id);
        }
    }
}
