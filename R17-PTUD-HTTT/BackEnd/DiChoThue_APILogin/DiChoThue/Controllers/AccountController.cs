using DiChoThue.Repository;
using DiChoThue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

namespace DiChoThue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration configuration;
        IUserRepository userRepository;

        public AccountController(IConfiguration _configuration, IUserRepository _userRepository)
        {
            configuration = _configuration;
            userRepository = _userRepository;
        }

        [HttpPost]
        [Route("Register/{type}")]
        public async Task<IActionResult> UserRegister([FromBody] UserInfo model, int type)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await userRepository.UserRegister(model, type);
                    if (userId > 0)
                        return Ok(userId);
                    else return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginInfo model)
        {
            var username = model.username;
            var password = model.password;
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userRepository.UserLogin(username, password);
                    if (user != null)
                        return Ok(user);
                    else
                        return NotFound();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
