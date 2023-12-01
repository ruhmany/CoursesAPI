using Application.Commands.StudentCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.StudentHandlers.CommandsHandlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteStudentHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Student> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentByID(request.Id);

            if(student != null)
            {
                _studentRepository.DeleteStudent(student);
                _unitOfWork.CommitChanges();
            }
            return student;
        }
    }
}
