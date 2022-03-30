using DiChoThue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiChoThue.Repository
{
    public interface IUserRepository
    {
        Task<int> UserRegister(UserInfo user, int type);
        Task<UserInfo> UserLogin(string username, string password);
        Task<UserInfo> GetUserById(int? userId);
        Task<UserInfo> GetUserByUserName(string username);
        Task UpdateUserInfo(UserInfo user);
    }
}
