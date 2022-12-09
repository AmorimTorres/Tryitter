using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;
using Rede_Social_Da_Galera___Tryitter.Repository;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PostController(IUnitOfWork context)
        {
            _uow = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = _uow.PostRepository.GetAll().ToList();
            if (posts is null)
            {
                return NotFound();
            }
            return Ok(posts);
        }
        [HttpGet("{id:int}", Name = "GetPosts")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = _uow.PostRepository.GetById(p => p.PostId == id);
            if (post is null) 
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post) 
        {
            _uow.PostRepository.Add(post);
            await _uow.Commit();
            return new CreatedAtRouteResult("GetPosts", new { id = post.PostId }, post);
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePost(int id, Post post)
        {
            if (post.PostId != id)
            {
                return BadRequest();
            }
            _uow.PostRepository.Update(post);
            await _uow.Commit();
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<Post>> DeletePost(int id) 
        {
            var post = await _uow.PostRepository.GetById(p => p.PostId == id);
            if (post is null)
            {
                return NotFound();
            }
            _uow.PostRepository.Delete(post); 
            await _uow.Commit();
            return Ok(post);
        }

    }
}
