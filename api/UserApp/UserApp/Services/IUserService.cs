using Microsoft.AspNetCore.Mvc;
using UserApp.Models;

namespace UserApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUse(User user);
        Task<User> UpdateUse(int id,User user);
        Task<bool> DeleteUse(int id);
    }
}
