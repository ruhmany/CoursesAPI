﻿using RahmanyCourses.Application.Commands.ContentCommands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using RahmanyCourses.Persentation.DTO;
using RahmanyCourses.Application.Models;

namespace RahmanyCourses.Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("add-content"), Authorize(Roles = "Instructor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddContent(AddContentDTO contentDTO)
        {
            var request = _mapper.Map<AddContentToCourseCommand>(contentDTO);
            request.CourseOwnerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _mediator.Send(request);
            var res = UnifiedResponse<ContentReturnModel>.Success(data: result);
            if (!result.IsCourseFound)
                res = UnifiedResponse<ContentReturnModel>.Error(message:"User Isn't Authrized To modify The Content");                
            if(!result.IsUserAuthorized)
                res = UnifiedResponse<ContentReturnModel>.Error(message: "User Isn't Authrized To modify The Content");
            return Ok(res);
        }


        [HttpPut("update-content"), Authorize("Instructor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<UnifiedResponse<ContentReturnModel>> UpdateContent(UpdateContentDTO updateContentDTO)
        {
            var request = _mapper.Map<UpdateContentCommand>(updateContentDTO);
            request.CourseOwnerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _mediator.Send(request);
            if (!result.IsCourseFound || result == null)
                return UnifiedResponse<ContentReturnModel>.Error(message: "Course Not Found");
            if (!result.IsUserAuthorized)
                return UnifiedResponse<ContentReturnModel>.Error(message: "User Isn't Authrized To modify The Content");
            return UnifiedResponse<ContentReturnModel>.Success(data: result);
        }


        [HttpDelete("delete-content"), Authorize("Instructor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<UnifiedResponse<DeleteContentModel>> DeleteContent(int contentid)
        {
            var request =new DeleteContentCommand { ContentId =  contentid };
            request.UserID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _mediator.Send(request);
            if (!result.IsFound || result == null)
                return UnifiedResponse<DeleteContentModel>.Error(message: "Content Not Found");
            if (!result.IsAuthorized)
                return UnifiedResponse<DeleteContentModel>.Error(message: "User Isn't Authrized To modify The Content");
            return  UnifiedResponse<DeleteContentModel>.Success(data: result);
        }
    }
}
