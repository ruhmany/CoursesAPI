using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance.Repositories
{
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
