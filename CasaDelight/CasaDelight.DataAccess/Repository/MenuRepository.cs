using CasaDelight.DataAccess.Data;
using CasaDelight.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDelight.DataAccess.Repository
{
    public class MenuRepository : Repository<Dish>
    {
        private readonly ApplicationDbContext _db;

        public MenuRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
