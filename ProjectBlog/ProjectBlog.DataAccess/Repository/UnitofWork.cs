
using ProjectBlog.DataAccess.Data;
using ProjectBlog.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlog.DataAccess.Repository
{
    public class UnitofWork : IUnitofWork
    { 

        private readonly ApplicationDbContext _db;

        private IRepository<Blog> _blogs;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;

        }

        public IRepository<Blog> Blogs => _blogs ??= new Repository<Blog>(_db);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _db.Dispose();

        }


        public async void Save()
        {
           await _db.SaveChangesAsync();
        }

    }
}
