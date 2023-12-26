using RahmanyCourses.Application.Commands.ContentCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Enums;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RahmanyCourses.Application.CommandHandlers.ContentCommandsHandlers
{
    internal class AddContentToCourseHandler : IRequestHandler<AddContentToCourseCommand, ContentReturnModel>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public AddContentToCourseHandler(IServiceProvider providor)
        {
            _mapper = providor.GetRequiredService<IMapper>();
            _videoService = providor.GetRequiredService<IVideoService>();
            _unitOfWork = providor.GetRequiredService<IUnitOfWork>();
            _courseRepository = providor.GetRequiredService<ICourseRepository>();
        }

        public async Task<ContentReturnModel> Handle(AddContentToCourseCommand request, CancellationToken cancellationToken)
        {
            string url = string.Empty;
            var course = await _courseRepository.GetById(request.CourseID);
            if (course == null)
                return new ContentReturnModel { IsCourseFound = false };
            if (course.InstructorID != request.CourseOwnerID)
                return new ContentReturnModel { IsCourseFound = true, IsUserAuthorized = false};
            if (request.Type == ContentType.Video)
            {
                var result = await _videoService.AddVideoAsync(request.Content);
                if(result.Error == null)
                url = result.Url.ToString();
            }
            var content = _mapper.Map<Content>(request);
            content.URL = url;
            course.Contents.Add(content);
            _courseRepository.Update(course);
            _unitOfWork.CommitChanges();

            return new ContentReturnModel { Title = content.Title, URL = content.URL, IsCourseFound = true, IsUserAuthorized = true };
        }
    }
}
