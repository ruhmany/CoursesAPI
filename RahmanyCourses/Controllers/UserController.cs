using Application.Commands.UserCommands;
using Application.Queries.UserQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UserController(IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }



        [HttpGet("get-all-users")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            var request = new GetAllUsersQuery();
            var result = await _mediator.Send(request);
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var time = DateTime.UtcNow;
            Log.Information("User:{@userID} get the all users data at{@time}", userID, time);
            return Ok(result);
        }

        [HttpGet("get-user-by-username")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers(GetUserByUsernameQuery request)
        {
            var result = await _mediator.Send(request);
            if (result == null)
                return NotFound("No user with this username");
            return Ok(result);
        }


        [HttpPut("update-user-email")]
        public async Task<IActionResult> UpdateUserEmail(UpdateUserEmailCommand request)
        {
            var result = await _mediator.Send(request);
            if(result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("update-user-password")]
        public async Task<IActionResult> UpdateUserPassword(UpdateUserPasswordCommand request)
        {
            var result = await _mediator.Send(request);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand request)
        {
            var result = await _mediator.Send(request);
            if(result == null)
                return NotFound();
            return Ok(result);
        }


        
    }
}
