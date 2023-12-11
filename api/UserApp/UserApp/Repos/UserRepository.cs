using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApp.Data;
using UserApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UserApp.Services;

namespace UserApp.Repos
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(UserDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> AddUse(User user)
        {
            try
            {
                if (user == null)
                {
                    return null;
                }
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return await Task.FromResult(new User());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<bool> DeleteUse(int id)
        {
            try
            {
                User userDel = await _context.Users.FindAsync(id);
                if (userDel == null)
                {
                    return true;
                }
                _context.Users.Remove(userDel);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                return await _context.Users.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<User> UpdateUse(int id, User user)
        {
            try
            {
                User user1 = await _context.Users.FindAsync(id);
                if (id == user1.Id)
                {
                    user1.Name = user.Name;
                    user1.Email = user.Email;
                    user1.Password = user.Password;
                    user1.PhoneNumber = user.PhoneNumber;
                    user1.Address = user.Address;
                }
                _context.Entry(user1);
                await _context.SaveChangesAsync();
                return user1;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }
    }
}
