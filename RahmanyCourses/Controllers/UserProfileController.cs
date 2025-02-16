using RahmanyCourses.Application.Commands.UserProfileCommands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RahmanyCourses.Persentation.Models;
using RahmanyCourses.Persentation.DTO;
using RahmanyCourses.Application.Models;

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
        public async Task<UnifiedResponse<UserProfileReturnModel>> AddProfile([FromForm]AddUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return UnifiedResponse<UserProfileReturnModel>.Success(data: result); 
        }

        [HttpPut("update-profile"), Authorize]
        public async Task<UnifiedResponse<UserProfileResponse>> UpdateProfilePic(UpdateProfilePictureCommand request)
        {
            var result = await _mediator.Send(request);
            if(request == null)
                return UnifiedResponse<UserProfileResponse>.Error(message: "User Not Found");
            var response = _mapper.Map<UserProfileResponse>(result);
            return UnifiedResponse<UserProfileResponse>.Success(data: response);
        }
    }
}
