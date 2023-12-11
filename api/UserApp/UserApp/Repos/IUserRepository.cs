using Microsoft.AspNetCore.Mvc;
using UserApp.Data;
using UserApp.Models;


namespace UserApp.Repos
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUse(User user);
        Task<User> UpdateUse(int id, User user);
        Task<bool> DeleteUse(int id);
    }
}
