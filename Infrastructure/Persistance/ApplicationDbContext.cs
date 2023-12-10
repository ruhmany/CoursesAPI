using Core.Entities;
using Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Course> Courses { get; set; }        
        public DbSet<CourseCategory> courseCategories { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Answer>(new AnswerConfigurations());
            modelBuilder.ApplyConfiguration<Content>(new ContentConfigurations());
            modelBuilder.ApplyConfiguration<CourseCategory>(new CourseCategoryConfigurations());
            modelBuilder.ApplyConfiguration<Course>(new CoursesConfigurations());
            modelBuilder.ApplyConfiguration<Discussion>(new DiscussionConfigurations());
            modelBuilder.ApplyConfiguration<Enrollment>(new EnrollmentConfigurations());
            modelBuilder.ApplyConfiguration<Notification>(new NotificationConfigurations());
            modelBuilder.ApplyConfiguration<Payment>(new PaymentConfigurations());
            modelBuilder.ApplyConfiguration<Progress>(new ProgressConfigurations());
            modelBuilder.ApplyConfiguration<Question>(new QuestionConfigurations());
            modelBuilder.ApplyConfiguration<Quiz>(new QuizConfigurations());
            modelBuilder.ApplyConfiguration<Rating>(new RatingConfigurations());
            modelBuilder.ApplyConfiguration<RefreshToken>(new RefreshTokenConfigurations());
            modelBuilder.ApplyConfiguration<User>(new UserConfigurations());
            modelBuilder.ApplyConfiguration<UserProfile>(new UserProfileConfigurations());
            base.OnModelCreating(modelBuilder);
        }

    }
}
