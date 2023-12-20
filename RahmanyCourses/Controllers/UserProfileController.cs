using RahmanyCourses.Application.Commands.UserProfileCommands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RahmanyCourses.Persentation.Models;

namespace RahmanyCourses.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("add-profile"), Authorize]
        public async Task<IActionResult> AddProfile([FromForm]AddUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);  
        }

        [HttpPut("update-profile"), Authorize]
        public async Task<IActionResult> UpdateProfilePic(UpdateProfilePictureCommand request)
        {
            var result = await _mediator.Send(request);
            if(request == null)
                return NotFound();
            var response = _mapper.Map<UserProfileResponse>(result);
            return Ok(response);
        }
    }
}
