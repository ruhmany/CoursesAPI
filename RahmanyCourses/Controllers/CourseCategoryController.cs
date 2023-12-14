using Application.Commands.CourseCategoryCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly IMediator _mdeiator;

        public CourseCategoryController(IMediator mdeiator)
        {
            _mdeiator = mdeiator;
        }

        [HttpPost("addcoursecategory"), Authorize(Roles = "Instructor")]
        public async Task<IActionResult> AddCourseCategory([FromBody]AddCourseCategoryCommand request)
        {
            var result = await _mdeiator.Send(request);
            return Ok(result);
        }
    }
}
