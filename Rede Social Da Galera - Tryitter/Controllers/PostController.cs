using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;
using Rede_Social_Da_Galera___Tryitter.Repository;
using System.Security.Claims;

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
            var posts = await _uow.PostRepository.GetAll().ToListAsync();
            if (posts is null)
            {
                return NotFound();
            }
            return Ok(posts);
        }
        [HttpGet("{id:int}", Name = "GetPosts")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _uow.PostRepository.GetById(p => p.PostId == id);
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
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePost(int id, Post post)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var getStudentId = Convert.ToInt16(claims.Claims.FirstOrDefault(c => c.Type == "StudentId").Value);

            if (getStudentId != post.StudentId)
            {
                return BadRequest("Usuário não autorizado");
            }

            if (post.PostId != id)
            {
                return BadRequest("Post não encontrado");
            }
            _uow.PostRepository.Update(post);
            await _uow.Commit();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
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
