using DiChoThue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiChoThue.Repository
{
    public interface IBuyerRepository
    {
        Task<int> CreateBuyer(int userId);
    }
}
