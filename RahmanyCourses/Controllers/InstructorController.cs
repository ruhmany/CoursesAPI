using Application.Commands.InstructorCommands;
using Application.Queries.InstructorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {        
        private readonly IMediator _mediator;
        public InstructorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllInstructorsQuery();
            var resut = await _mediator.Send(query);
            return Ok(resut);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetinstructorByIDQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructor(AddInstructorCommand addInstructorCommand)
        {
            var result = await _mediator.Send(addInstructorCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorCommand updateInstructorCommand)
        {
            var result = await _mediator.Send(updateInstructorCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInstructor(DeleteInstructorCommand deleteInstructorCommand)
        {
            var resut = await _mediator.Send(deleteInstructorCommand);
            return Ok();
            
        }


    }
}
