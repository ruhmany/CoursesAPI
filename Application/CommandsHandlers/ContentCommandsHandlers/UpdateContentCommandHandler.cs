using AutoMapper;
using MediatR;
using RahmanyCourses.Application.Commands.ContentCommands;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace RahmanyCourses.Application.CommandsHandlers.ContentCommandsHandlers
{
    internal class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, ContentReturnModel>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideoService _videoService;

        public UpdateContentCommandHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _videoService = provider.GetRequiredService<IVideoService>();
            _contentRepository = provider.GetRequiredService<IContentRepository>();
        }

        public async Task<ContentReturnModel> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetById(request.ContentID);
            if(content == null)
                return new ContentReturnModel { IsCourseFound = false };
            if (content.Course.InstructorID != request.CourseOwnerID)
                return new ContentReturnModel { IsCourseFound = true, IsUserAuthorized = false };
            await _videoService.DeleteVideoAsync(content.URL);
            var result = await _videoService.AddVideoAsync(request.Content);
            var newURL = result.Url.ToString();
            content.URL = newURL;
            content.Title = request.Title;
            _contentRepository.Update(content);
            _unitOfWork.CommitChanges();
            return new ContentReturnModel { Title = content.Title, URL = content.URL, IsCourseFound = true, IsUserAuthorized = true };

        }
    }
}
