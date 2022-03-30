using DiChoThue.Models;
using DiChoThue.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiChoThue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        IUserRepository userRepository;

        public UserInfoController( IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpGet("check-exists/{username}")]
        public async Task<ActionResult<UserInfo>> GetUserByUsername(string username)
        {
            var user = await userRepository.GetUserByUserName(username);
            if (user == null) return NotFound();
            return user;
        }
    }
}
