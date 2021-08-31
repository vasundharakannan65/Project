using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.DataAccess.Repository
{
    public interface IUnitofWork : IDisposable
    {
        void Save();
    }
}
