using Application.Commands.CourseCommands;
using Application.Commands.UserCommands;
using Application.Queries.CourseQueries;
using Application.Queries.UserQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RahmanyCourses.DTO;
using RahmanyCourses.Models;
using System.Security.Claims;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CourseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // Get All Courses With Its Rates.

        [HttpGet("get-my-created-courses")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> GetMyCourses()
        {
            int instructorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = new GetCreatedCoursesCommand { UserId = instructorId };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get-course-by-id")]
        public async Task<IActionResult> GetCourseById([FromQuery]GetCourseByIdQuery request)
        {
            var result = await _mediator.Send(request);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("add-course"), Authorize(Roles = "Instructor")]
        public async Task<IActionResult> AddCourse(CourseModel model)
        {
            var request = _mapper.Map<AddCourseCommand>(model);
            request.InstructorID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("enroll-in-course"), Authorize]
        public async Task<IActionResult> EnrollInCourse(int courseID)
        {
            int studentid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = new EnrollInCourseCommand { CourseID = courseID, StudentID = studentid };
            var result = await _mediator.Send(request);
            if(!result.IsCourseAvailable)
                return NotFound(result);
            if(!result.IsUserAllowedToEnroll) 
                return BadRequest(new { Message = "You can't enroll in your courses" });
            return Ok(new { CourseId = result.CourseID, studentid = request.StudentID });
        }

        [HttpPost("rate-course")]
        [Authorize]
        public async Task<IActionResult> RateCourse(RateCourseDTO dTO)
        {
            int studentid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = _mapper.Map<RateCourseCommand>(dTO);
            request.StudentID = studentid;
            var result = await _mediator.Send(request);
            if (result == null)
                return BadRequest("you aren't enrolled in this course");
            return Ok(result);
        }
    }
}
