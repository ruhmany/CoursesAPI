using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.AsQueryable().Where(u => u.Email == email).FirstOrDefaultAsync();
        }
        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.AsQueryable().Where(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}
