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
    public class GetAllStudentsHnadler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsHnadler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAllStudents();
        }
    }
}
