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
    public class CommentController : ControllerBase
    {
        private readonly UnitofWork _unitofWork;

        public CommentController(UnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        //getting all comments
        [HttpGet]
        public async Task<IEnumerable<Comment>> GetCommentList()
        {
            return await _unitofWork.Comments.GetAll();
        }

        //single comment
        [HttpGet("{id}")]
        public async Task<Comment> GetCommentById(int id)
        {
            var existingComment = await _unitofWork.Comments.Get(id);

            return existingComment;
        }

        //create comment
        [HttpPost]
        public async Task<Comment> CreateComment(Comment comment)
        {
            await _unitofWork.Comments.Add(comment);
            _unitofWork.Save();
            return comment;
        }

        //update comment
        [HttpPut]
        public void UpdateComment(Comment comment)
        {
            Comment newComment = new()
            {
                CommentContent = comment.CommentContent
            };

            _unitofWork.Comments.Update(newComment);
            _unitofWork.Save();

        }

        //delete comment
        [HttpDelete("{id}")]
        public async void DeleteComment(int id)
        {
            var comment = await _unitofWork.Comments.Get(id);
            _unitofWork.Comments.Remove(comment);
            _unitofWork.Save();
        }
    }
}
