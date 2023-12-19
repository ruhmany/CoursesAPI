using Application.Commands.ContentCommands;
using Application.Models;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UnitOfWork;
using MediatR;

namespace Application.CommandHandlers.ContentCommandsHandlers
{
    internal class AddContentToCourseHandler : IRequestHandler<AddContentToCourseCommand, ContentReturnModel>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public AddContentToCourseHandler(IMapper mapper, IVideoService videoService, IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _videoService = videoService;
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
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
