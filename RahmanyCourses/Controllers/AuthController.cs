﻿using RahmanyCourses.Application.Commands.UserCommands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RahmanyCourses.Persentation.Models;
using FluentValidation;
using System.Diagnostics;
using Microsoft.Extensions.Primitives;
using System.Runtime.CompilerServices;
using RahmanyCourses.Persentation.DTO;
using RahmanyCourses.Application.Models;

namespace RahmanyCourses.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IValidator<AddUserCommand> addUserValidator;
        private readonly IValidator<GetUserTokenCommand> getUserTokenValidator;

        public AuthController(IServiceProvider provider)
        {
            _mediator = provider.GetRequiredService<IMediator>();
            _configuration = provider.GetRequiredService<IConfiguration>();
            addUserValidator = provider.GetRequiredService<IValidator<AddUserCommand>>();
            getUserTokenValidator = provider.GetRequiredService<IValidator<GetUserTokenCommand>>();
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<UnifiedResponse<AuthModel>> Register(AddUserCommand command)
        {
            var validationResult = await addUserValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return UnifiedResponse<AuthModel>.Error("Validation Error", 500);
            }
            var userResponse = await _mediator.Send(command);
            if (userResponse == null)
            {
                return UnifiedResponse<AuthModel>.Error("Internal Error", 500);
            }
            return UnifiedResponse<AuthModel>.Success(userResponse);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<UnifiedResponse<AuthModel>> Login(GetUserTokenCommand query)
        {
            var validationResult = await getUserTokenValidator.ValidateAsync(query);
            if(!validationResult.IsValid)
            {
                return UnifiedResponse<AuthModel>.Error("Validation Error", 500);
            }
            var userResponse = await _mediator.Send(query);
            if (userResponse == null)
            {
                return UnifiedResponse<AuthModel>.Error("Internal Error", 500);
            }
            return UnifiedResponse<AuthModel>.Success(userResponse, "Login Successfully");
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
