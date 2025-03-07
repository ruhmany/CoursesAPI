﻿using RahmanyCourses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Interfaces.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IEnumerable<Course>> GetTopRatedCourses();
        Task<IEnumerable<Course>> GetEnrolledInCourses(int userId);
        Task<IEnumerable<Course>> GetOwnedCourses();
    }
}
