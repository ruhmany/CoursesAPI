using Bogus;
using FakeItEasy;
using RahmanyCourses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Test.Repositories
{
    public class TestDataSeeder
    {
        public static List<Course> SeedCourseEntities(int count)
        {
            var faker = new Faker<Course>();
            return faker.Generate(count);
        }
    }
}
