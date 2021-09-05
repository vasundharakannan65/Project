using CasaDelight.DataAccess.Data;
using CasaDelight.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDelight.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
