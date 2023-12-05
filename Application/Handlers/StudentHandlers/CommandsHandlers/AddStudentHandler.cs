using Application.Commands.StudentCommands;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Handlers.StudentHandlers.CommandsHandlers
{
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public AddStudentHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IAuthService authService)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {

            _authService.CreateHashPassword(request.Password, out byte[] passwordhash, out byte[] PasswordSalt);
            var student = new Student
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordhash,
                PasswordSalt = PasswordSalt,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserType = UserType.Student,
                Token = ""
            };
            
            await _studentRepository.AddStudent(student);
            _unitOfWork.CommitChanges();
            student.Token = _authService.CreateToken(student);
            _unitOfWork.CommitChanges();
            return student;
        }
    }
}
