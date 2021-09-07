
using ProjectBlog.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlog.DataAccess.Repository
{
    public interface IUnitofWork : IDisposable
    {

        public IRepository<Blog> Blogs { get; }
        void Save();
    }
}
