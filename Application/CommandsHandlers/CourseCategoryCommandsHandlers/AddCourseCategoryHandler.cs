using RahmanyCourses.Application.Commands.CourseCategoryCommands;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.CommandHandlers.CourseCategoryCommandsHandlers
{
    internal class AddCourseCategoryHandler : IRequestHandler<AddCourseCategoryCommand, CourseCategory>
    {
        private readonly IcourseCategoryRepository _courseCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddCourseCategoryHandler(IcourseCategoryRepository courseCategoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _courseCategoryRepository = courseCategoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CourseCategory> Handle(AddCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            var courseCategory = _mapper.Map<CourseCategory>(request);
            await _courseCategoryRepository.Add(courseCategory);
            _unitOfWork.CommitChanges();
            return courseCategory;
        }
    }
}
