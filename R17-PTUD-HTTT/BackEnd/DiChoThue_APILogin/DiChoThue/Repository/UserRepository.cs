using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiChoThue.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using BCrypt;

namespace DiChoThue.Repository
{
    public class UserRepository : IUserRepository
    {
        CoreDbContext db;
        public UserRepository(CoreDbContext _db)
        {
            db = _db;
        }

        public async Task<int> UserRegister(UserInfo user, int type)
        {
            if (db != null)
            {
                var _user = new UserInfo(user);
                if (type == 1) _user.Buyer = new Buyer(_user.UserId);
                if (type == 2) _user.Seller = new Seller(_user.UserId);
                if (type == 3) _user.Shipper = new Shipper(_user.UserId);
                _user.UserPassword = BCrypt.Net.BCrypt.HashPassword(_user.UserPassword);
                await db.UserInfo.AddAsync(_user);
                await db.SaveChangesAsync();
               
                return _user.UserId;
            }
            return 0;
        }

        public async Task<UserInfo> GetUserById(int? userId)
        {
            if (db != null)
            {
                return await (from u in db.UserInfo
                              where u.UserId == userId
                              select new UserInfo(u)).FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<UserInfo> GetUserByUserName(string username)
        {
            if (db != null)
            {
                UserInfo userInfo = await (from u in db.UserInfo
                                           join b in db.Buyer on u.UserId equals b.UserId into gr from b in gr.DefaultIfEmpty()
                                           join se in db.Seller on u.UserId equals se.UserId into gr1 from se in gr1.DefaultIfEmpty()
                                           join sp in db.Shipper on u.UserId equals sp.UserId into gr2 from sp in gr2.DefaultIfEmpty()
                                           where u.UserLoginName == username 
                                           select (new UserInfo()
                                           {
                                               UserId = u.UserId,
                                               UserAddress = u.UserAddress,
                                               UserArea = u.UserArea,
                                               UserBirth = u.UserBirth,
                                               UserEmail = u.UserEmail,
                                               UserGender = u.UserGender,
                                               UserImg = u.UserImg,
                                               UserLoginName = u.UserLoginName,
                                               UserName = u.UserName,
                                               UserPassword = u.UserPassword,
                                               UserPhone = u.UserPhone,
                                               Buyer =new Buyer() { UserId = b.UserId , BuyerDiscount = b.BuyerDiscount },
                                               Seller = new Seller() { UserId = se.UserId},
                                               Shipper =new Shipper() { UserId = sp.UserId,ShipperRate = sp.ShipperRate}
                                           })).FirstOrDefaultAsync();
                return userInfo;
            }
            return null;
        }
        public async Task UpdateUserInfo(UserInfo user)
        {
            if (db!= null)
            {
                db.UserInfo.Update(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<UserInfo> UserLogin(string username, string password)
        {
            if (db != null)
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return null;
                var user = await GetUserByUserName(username);
                if (user == null) return null;
                if (!BCrypt.Net.BCrypt.Verify(password, user.UserPassword)) return null;
                return user;
            }
            return null;
        }
    }
}
