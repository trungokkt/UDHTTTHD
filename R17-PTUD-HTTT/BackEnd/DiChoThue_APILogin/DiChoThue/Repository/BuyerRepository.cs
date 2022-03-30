using DiChoThue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiChoThue.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        CoreDbContext db;
        public BuyerRepository(CoreDbContext _db)
        {
            db = _db;
        }
        public async Task<int> CreateBuyer(int userId)
        {
            if (db != null)
            {
                var buyer = new Buyer(userId);
                await db.Buyer.AddAsync(buyer);
                await db.SaveChangesAsync();
                return buyer.UserId;
            }
            return 0;
        }
    }
}
