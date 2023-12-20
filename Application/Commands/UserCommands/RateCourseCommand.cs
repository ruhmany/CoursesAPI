using RahmanyCourses.Core.Entities;
using MediatR;

namespace RahmanyCourses.Application.Commands.UserCommands
{
    public class RateCourseCommand :IRequest<Rating>
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public float RatingValue { get; set; }
        public string RateMessage { get; set; }
    }
}
