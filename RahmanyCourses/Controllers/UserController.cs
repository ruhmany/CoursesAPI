using Application.Commands.UserCommands;
using Application.Queries.UserQueries;
using AutoMapper;
using Core.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RahmanyCourses.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            var request = new GetAllUsersQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get-user-by-username")]
        [Authorize]
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


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(GetUserTokenCommand query)
        {
            var userResponse = await _mediator.Send(query);
            if(userResponse == null)
            {
                return BadRequest();
            }
            return Ok(userResponse);
        }

        [HttpPost("Refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokensModel model)
        {
            var princible = GetClaimsPrincipalFromExpiredToken(model.Token);
            if (princible?.Identity?.Name is null)
                return Unauthorized();
            var request = new CreateNewTokensCommand 
            {
                Username = princible.Identity.Name,
                Token = model.Token,
                RefreshToken = model.RefreshToken
            };
            var result = await _mediator.Send(request);      
            if (result == null)
                return Unauthorized();
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


        private ClaimsPrincipal? GetClaimsPrincipalFromExpiredToken(string? token)
        {
            var validation = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:Issuer"],
                ValidAudience = _configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                ValidateLifetime = false
            };
            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
    }
}
