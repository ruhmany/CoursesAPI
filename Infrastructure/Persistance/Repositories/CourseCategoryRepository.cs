using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class CourseCategoryRepository : BaseRepository<CourseCategory>, IcourseCategoryRepository
    {
        public CourseCategoryRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
