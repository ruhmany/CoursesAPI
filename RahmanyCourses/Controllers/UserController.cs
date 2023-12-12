using Application.Commands.UserCommands;
using Application.Queries.UserQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AddUserCommand command)
        {
            var userResponse = await _mediator.Send(command);
            if(userResponse == null)
            {
                return BadRequest();
            }
            return Ok(userResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(GetUserTokenQuery query)
        {
            var userResponse = await _mediator.Send(query);
            if(userResponse == null)
            {
                return BadRequest();
            }
            return Ok(userResponse);
        }
    }
}
