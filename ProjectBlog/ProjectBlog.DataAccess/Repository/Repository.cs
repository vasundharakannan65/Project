
using Microsoft.EntityFrameworkCore;
using ProjectBlog.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlog.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<T> Get(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return entity;
            
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public async void Remove(int id)
        {
            var entity = await _db.FindAsync<T>(id);
            _db.Remove(entity);
        }

        public void Update(T entity)
        {
             _db.Update(entity);
        }

        public async void Update(int id)
        {
            var entity = await _db.FindAsync<T>(id);
            _db.Update(entity);
        }

    }
}
