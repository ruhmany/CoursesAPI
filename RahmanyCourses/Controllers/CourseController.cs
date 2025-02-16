using RahmanyCourses.Application.Commands.CourseCommands;
using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Queries.CourseQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using RahmanyCourses.Persentation.Models;
using RahmanyCourses.Persentation.DTO;
using RahmanyCourses.Application.FilterService;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Application.Models;

namespace RahmanyCourses.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly GenericFilter<Course> _genericFilter;

        public CourseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("get-all-courses")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<UnifiedResponse<IEnumerable<CourseReturnModel>>> GetAllCourses()
        {
            var request = new GetAllCoursesQuery();
            var result = await _mediator.Send(request);
            return UnifiedResponse<IEnumerable<CourseReturnModel>>.Success(data: result);
        }

        [HttpPost("filtered-courses")]
        public async Task<UnifiedResponse<IEnumerable<CourseReturnModel>>> GetData(FilterModel<Course> filters)
        {
            try
            {
                var query = new GetFilteredCoursesQuery { Filters = filters };
                var result = await _mediator.Send(query);

                return UnifiedResponse<IEnumerable<CourseReturnModel>>.Success(data: result);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return UnifiedResponse<IEnumerable<CourseReturnModel>>.Error(message: ex.Message);
            }
        }



        // Get All Courses With Its Rates.
        [HttpGet("get-all-enrolled-in-courses")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<UnifiedResponse<IEnumerable<CourseReturnModel>>> GetAllEnrolledInCourses()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = new GetEnrolledInCoursesQuery { UserId = userId};
            var result = await _mediator.Send(request);
            return UnifiedResponse<IEnumerable<CourseReturnModel>>.Success(data: result);
        }

        [HttpGet("get-top-rated-courses")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<UnifiedResponse<IEnumerable<CourseReturnModel>>> GetTopRatedCourses()
        {
            var request = new GetTopRatedCoursesQuery();
            var result = await _mediator.Send(request);
            return UnifiedResponse<IEnumerable<CourseReturnModel>>.Success(data: result);
        }

        [HttpGet("get-my-created-courses")]
        [Authorize(Roles = "Instructor")]
        public async Task<UnifiedResponse<IEnumerable<CourseReturnModel>>> GetMyCourses()
        {
            int instructorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = new GetCreatedCoursesQuery { UserId = instructorId };
            var result = await _mediator.Send(request);
            return UnifiedResponse<IEnumerable<CourseReturnModel>>.Success(data: result);
        }

        [HttpGet("get-course-by-id")]
        public async Task<UnifiedResponse<CourseReturnModel>> GetCourseById([FromQuery]GetCourseByIdQuery request)
        {
            var result = await _mediator.Send(request);
            if (result == null)
                return UnifiedResponse<CourseReturnModel>.Error(message: "Course Not Found");
            return UnifiedResponse<CourseReturnModel>.Success(data: result);
        }

        [HttpPost("add-course"), Authorize(Roles = "Instructor")]
        public async Task<UnifiedResponse<CourseReturnModel>> AddCourse(CourseModel model)
        {
            var request = _mapper.Map<AddCourseCommand>(model);
            request.InstructorID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _mediator.Send(request);
            return UnifiedResponse<CourseReturnModel>.Success(data: result);
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
        public async Task<UnifiedResponse<Rating>> RateCourse(RateCourseDTO dTO)
        {
            int studentid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = _mapper.Map<RateCourseCommand>(dTO);
            request.StudentID = studentid;
            var result = await _mediator.Send(request);
            if (result == null)
                return UnifiedResponse<Rating>.Error(message: "You aren't enrolled in this course");
            return UnifiedResponse<Rating>.Success(data: result);
        }


        [HttpDelete("delete-course")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<UnifiedResponse<DeleteCourseResult>> DeleteCourse(int courseId)
        {
            int ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var request = new DeleteCourseCommand { CourseID = courseId, UserID = ownerId };
            var result = await _mediator.Send(request);
            if (!result.IsFound)
                return UnifiedResponse<DeleteCourseResult>.Error(message: "Course Not Found");
            if (!result.IsUserAuthorized)
                return UnifiedResponse<DeleteCourseResult>.Error(message: "User Isn't Authrized To delete The Course");
            return UnifiedResponse<DeleteCourseResult>.Success(data: result);
        }
    }
}