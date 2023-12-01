using Application.Commands.CourseCommands;
using Application.Queries.CourseQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {      
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCourses()
        {
            var query = new GetAllCoursesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetById(GetCourseByIdQuery query)
        {
            var result =  await _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourseCommand addCourseCommand)
        {
            var result = await _mediator.Send(addCourseCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand updateCourseCommand)
        {
            var result = await _mediator.Send(updateCourseCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(DeleteCourseCommand deleteCourseCommand)
        {
            var result = await _mediator.Send(deleteCourseCommand);
            return Ok();
        }
    }
}
