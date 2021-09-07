using ProjectBlog.DataAccess.Data;
using ProjectBlog.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlog.DataAccess.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        private readonly ApplicationDbContext _db;
        public BlogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
