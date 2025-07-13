using RahmanyCourses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Interfaces.Repositories
{
    public interface IUserFollowRepository
    {
        Task<bool> FollowUserAsync(int followerId, int followedId);
        Task<bool> UnfollowUserAsync(int followerId, int followedId);
        Task<List<User>> GetFollowers(int userId);
        Task<List<User>> GetFollowing(int userId);
    }
}
