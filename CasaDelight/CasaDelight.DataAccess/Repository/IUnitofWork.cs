using CasaDelight.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDelight.DataAccess.Repository
{
    public interface IUnitofWork : IDisposable
    {
        public IRepository<Dish> Dishes { get; }

        public IRepository<Order> Orders { get; }
        
        void Save();
    }
}
