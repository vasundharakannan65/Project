
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlog.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Update(T entity);
        void Update(int id);
    }
}
