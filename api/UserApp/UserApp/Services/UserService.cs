using Microsoft.AspNetCore.Mvc;
using UserApp.Models;
using UserApp.Repos;

namespace UserApp.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _UserRepos;
        public UserService(IUserRepository UserRepos)
        {
            _UserRepos = UserRepos;
        }
        public async Task<User> AddUse(User user)
        {
            return await _UserRepos.AddUse(user);
        }

        public async Task<bool> DeleteUse(int id)
        {
            return await (_UserRepos.DeleteUse(id));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _UserRepos.GetUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _UserRepos.GetUserById(id);
        }

        public async Task<User> UpdateUse(int id, User user)
        {
            return await _UserRepos.UpdateUse(id, user);
        }
    }
}
