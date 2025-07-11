using RahmanyCourses.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RahmanyCourses.Infrastructure.Persistance.Configurations;
using RahmanyCourses.Infrastructure.Persistance.Helpers;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace RahmanyCourses.Infrastructure.Persistance
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
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<UsedCoupons> UsedCoupons { get; set; }
        public DbSet<RateReport> RateReports { get; set; }
        public DbSet<ContentReport> ContentReports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public  DbSet<User> Users { get; set; }


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
            modelBuilder.ApplyConfiguration<Coupon>(new CouponConfigurations());
            modelBuilder.ApplyConfiguration<UsedCoupons>(new  UsedCouponsConfigurations());
            modelBuilder.ApplyConfiguration<ContentReport>(new ContentReportConfigurations());
            modelBuilder.ApplyConfiguration<RateReport>(new RateReportConfigurations());
            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if(entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;                    
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity ,true);
                }
            }
            return base.SaveChanges();
        }

    }
}
