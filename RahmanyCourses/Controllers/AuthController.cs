using Application.Commands.UserCommands;
using Application.Queries.UserQueries;
using AutoMapper;
using Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RahmanyCourses.Models;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RahmanyCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthController(IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }



        


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(AddUserCommand command)
        {
            var userResponse = await _mediator.Send(command);
            if (userResponse == null)
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
            if (userResponse == null)
            {
                return BadRequest();
            }
            return Ok(userResponse);
        }

        [HttpPost("refresh")]
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
