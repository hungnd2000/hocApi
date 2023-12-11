using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApp.Data;
using UserApp.Models;
using UserApp.Services;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
          return await _service.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {
            return await _service.GetUserById(id);
        }

        //// PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<User> UpdateUser(int id, User user)
        {
            return await _service.UpdateUse(id, user);
        }

        //// POST: api/Users
        [HttpPost]
        public async Task<User> AddUser(User user)
        {
            return await _service.AddUse(user);
        }

        //// DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(int id)
        {
            return await (_service.DeleteUse(id));
        }
    }
}
