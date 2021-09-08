using Microsoft.AspNetCore.Mvc;
using ProjectBlog.DataAccess.Repository;
using ProjectBlog.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;

        public BlogController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        //getting all blogs
        [HttpGet]
        public async Task<IEnumerable<Blog>> GetBlogList()
        {
            return await _unitofWork.Blogs.GetAll();
        }

        //single blog
        [HttpGet("{id}")]
        public async Task<Blog> GetBlogById(int id)
        {
            var existingBlog = await _unitofWork.Blogs.Get(id);

            return existingBlog;
        }

        //create blog
        [HttpPost]
        public async Task<Blog> CreateBlog(Blog blog)
        {
            await _unitofWork.Blogs.Add(blog);
            _unitofWork.Save();
            return blog;
        }

        //update blog
        [HttpPut]
        public void UpdateBlog(Blog blog)
        {
            Blog newBlog = new()
            {
                BlogTitle = blog.BlogTitle,
                BlogContent = blog.BlogContent
            };

            _unitofWork.Blogs.Update(newBlog);
            _unitofWork.Save();

        }

        //delete blog
        [HttpDelete("{id}")]
        public async void DeleteBlog(int id)
        {
            var blog = await _unitofWork.Blogs.Get(id);
            _unitofWork.Blogs.Remove(blog);
            _unitofWork.Save();
        }
    }
}
