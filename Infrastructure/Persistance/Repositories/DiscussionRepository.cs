using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance.Repositories
{
    public class DiscussionRepository : BaseRepository<Discussion>, IDiscussionRepository
    {
        public DiscussionRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
