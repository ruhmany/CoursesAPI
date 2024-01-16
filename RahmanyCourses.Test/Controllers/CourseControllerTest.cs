using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.CourseQueries;
using AutoMapper;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RahmanyCourses.Persentation.Controllers;

namespace RahmanyCourses.Test.Controllers
{
    public class CourseControllerTest
    {
        [Fact]
        public async Task GetTopRatedCourse_ShouldRetrunOkResult()
        {
            //Arrange
            var mediatorFake = A.Fake<IMediator>();
            var mapperFake = A.Fake<IMapper>();
            var fakecourses = A.CollectionOfDummy<CourseReturnModel>(5).AsEnumerable();
            A.CallTo(() => mediatorFake.Send(A<GetTopRatedCoursesQuery>._, A<CancellationToken>._))
                .Returns(Task.FromResult(fakecourses));
            var controller = new CourseController(mediatorFake, mapperFake);
            
            //Act
            var result = await controller.GetTopRatedCourses();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CourseReturnModel>>(okResult.Value);
        }
    }
}
