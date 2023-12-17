using Application.Commands.UserCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsHandlers.UserCommandsHandlers
{
    internal class RateCourseHandler : IRequestHandler<RateCourseCommand, Rating>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RateCourseHandler(IUnitOfWork unitOfWork, IEnrollmentRepository enrollmentRepository, IRatingRepository ratingRepository)
        {
            _unitOfWork = unitOfWork;
            _enrollmentRepository = enrollmentRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task<Rating> Handle(RateCourseCommand request, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentRepository.GetById(request.StudentID, request.CourseID);
            if (enrollment == null)
                return null;
            var reating = new Rating { CourseID = request.CourseID, UserID = request.StudentID, 
                RateMessage = request.RateMessage, RatingValue = request.RatingValue };
            await _ratingRepository.Add(reating);
            _unitOfWork.CommitChanges();
            return reating;
        }
    }
}
