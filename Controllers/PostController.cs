using Microsoft.AspNetCore.Mvc;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PostController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            var posts = _context.Posts.ToList();
            if (posts is null)
            {
                return NotFound();
            }
            return Ok(posts);
        }
        [HttpGet("{id:int}", Name = "GetPosts")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);
            if (post is null) 
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpPost]
        public ActionResult<Post> CreatePost(Post post) 
        {
            if (post is null)
            {
                return BadRequest();
            }
            _context.Posts.Add(post);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetPosts", new { id = post.PostId }, post);
        }

    }
}
