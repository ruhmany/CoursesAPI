using MediatR;
using RahmanyCourses.Application.Commands.ContentCommands;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.CommandsHandlers.ContentCommandsHandlers
{
    internal class DeleteConetenCommandHandler : IRequestHandler<DeleteContentCommand, DeleteContentModel>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConetenCommandHandler(IContentRepository contentRepository, IUnitOfWork unitOfWork)
        {
            _contentRepository = contentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteContentModel> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetById(request.ContentId);
            if (content == null)
            {
                return new DeleteContentModel { IsFound = false };
            }
            if(content.Course.InstructorID != request.UserID)
                return new DeleteContentModel { IsFound = true, IsAuthorized = false };
            _contentRepository.Delete(content);
            _unitOfWork.CommitChanges();
            return new DeleteContentModel { Title = content.Title, IsAuthorized = true, IsFound = true };
        }
    }
}
