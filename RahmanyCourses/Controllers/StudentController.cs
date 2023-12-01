using Application.Commands.StudentCommands;
using Application.Queries.StudentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            var request = new GetAllStudentsQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetAllStudents(GetStudentByIDQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(DeleteStudentCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
