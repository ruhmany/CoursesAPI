using Application.Commands.CourseCommands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RahmanyCourses.Models;
using System.Security.Claims;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCountroller : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CourseCountroller(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("add-course"), Authorize(Roles = "Instructor")]
        public async Task<IActionResult> AddCourse(CourseModel model)
        {
            var request = _mapper.Map<AddCourseCommand>(model);
            request.InstructorID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
