using Application.Commands.EnrollmentCommands;
using Application.Queries.EnrollmentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllEnrollments")]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var query = new GetAllEnrollmentQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetEnrollmentById")]
        public async Task<IActionResult> GetEnrollmentById(GetEnrollmentByIdQuery getEnrollmentById)
        {
            var result = await _mediator.Send(getEnrollmentById);
            return Ok(result);
        }

        [HttpGet("GetEnrollmentByStudentId")]
        public async Task<IActionResult> GetEnrollmentByStudentId(GetEnrollmentsByStudentIdQuery getEnrollmentsByStudentId)
        {
            var result = await _mediator.Send(getEnrollmentsByStudentId);
            return Ok(result);
        }

        [HttpGet("GetEnrollmentByCourseID")]
        public async Task<IActionResult> GetEnrollmentsByCourseId(GetEnrollmentByCourseIdQuery getEnrollmentsByCourseId)
        {
            var result = await _mediator.Send(getEnrollmentsByCourseId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(AddEnrollmentCommand addEnrollment)
        {
            var result = await _mediator.Send(addEnrollment);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEnrollment(DeleteEnrollmentCommand deleteEnrollment)
        {
            var result = await _mediator.Send(deleteEnrollment);
            return Ok(result);
        }
    }
}
