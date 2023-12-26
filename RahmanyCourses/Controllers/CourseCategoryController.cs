using RahmanyCourses.Application.Commands.CourseCategoryCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using System.Security.Claims;
using RahmanyCourses.Application.Commands.CourseCommands;

namespace RahmanyCourses.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addcoursecategory"), Authorize(Roles = "Instructor")]
        public async Task<IActionResult> AddCourseCategory([FromBody]AddCourseCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }        
    }
}
