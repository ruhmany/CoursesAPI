using Application.Models;
using Application.Queries.CourseQueries;
using Application.Queries.UserQueries;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RahmanyCourses.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Test.Controllers
{
    public class CourseControllerTest
    {
        [Fact]
        public async Task GetTopRatedCourse_ShouldRetrunOkResult()
        {
            //Arrange
            var mediatorFake = A.Fake<IMediator>();
            var mapper = A.Fake<IMapper>();
            var fakecourses = A.CollectionOfDummy<CourseReturnModel>(5).AsEnumerable();
            A.CallTo(() => mediatorFake.Send(A<GetTopRatedCoursesQuery>._, A<CancellationToken>._))
                .Returns(Task.FromResult(fakecourses));
            var controller = new CourseController(mediatorFake, mapper);
            
            //Act
            var result = await controller.GetTopRatedCourses();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CourseReturnModel>>(okResult.Value);
        }
    }
}
