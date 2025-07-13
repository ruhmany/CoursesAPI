using Microsoft.EntityFrameworkCore;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance.Repositories
{
    public class UserFollowerRepository : IUserFollowRepository
    {
        private readonly ApplicationDbContext _context;

        public UserFollowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> FollowUserAsync(int followerId, int followedId)
        {
            var follow = new UserFollow
            {
                FollowerId = followerId,
                FollowingId = followedId,
                FollowedOn = DateTime.UtcNow
            };

            _context.UserFollows.Add(follow);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<User>> GetFollowers(int userId)
        {
            return await _context.UserFollows
                    .Where(uf => uf.FollowingId == userId)
                    .Select(uf => uf.Follower)
                    .ToListAsync();
        }

        public async Task<List<User>> GetFollowing(int userId)
        {
            return await _context.UserFollows
                        .Where(uf => uf.FollowerId == userId)
                        .Select(uf => uf.Following)
                        .ToListAsync();
        }

        public async Task<bool> UnfollowUserAsync(int followerId, int followedId)
        {
            var follower = _context.UserFollows
                .FirstOrDefault(uf => uf.FollowerId == followerId && uf.FollowingId == followedId);
            if (follower != null)
            {
                _context.UserFollows.Remove(follower);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
