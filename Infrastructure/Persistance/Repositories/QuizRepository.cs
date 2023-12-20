using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance.Repositories
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
