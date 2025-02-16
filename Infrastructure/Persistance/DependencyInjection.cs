using Microsoft.Extensions.DependencyInjection;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using RahmanyCourses.Infrastructure.Persistance.Repositories;
using RahmanyCourses.Infrastructure.Persistance.Services;
using RahmanyCourses.Infrastructure.Persistance.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            return services.AddScoped<IAuthService, AuthService>()
                    .AddScoped<IPhotoService, PhotoService>()
                    .AddScoped<IVideoService, VideoService>()
                    .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                    .AddScoped<IAnswerRepository, AnswerRepository>()
                    .AddScoped<IContentRepository, ContentRepository>()
                    .AddScoped<ICourseRepository, CourseRepository>()
                    .AddScoped<ICourseCategoryRepository, CourseCategoryRepository>()
                    .AddScoped<IDiscussionRepository, DiscussionRepository>()
                    .AddScoped<IEnrollmentRepository, EnrollmentRepository>()
                    .AddScoped<INotificationsRepository, NotifcationRepository>()
                    .AddScoped<IPaymentRepository, PaymentRepository>()
                    .AddScoped<IProgressRepository, ProgressRepository>()
                    .AddScoped<IQuestionRepository, QuestionRepository>()
                    .AddScoped<IQuizRepository, QuizRepository>()
                    .AddScoped<IRatingRepository, RatingRepository>()
                    .AddScoped<IUserProfileRepository, UserProfileRepository>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }

}