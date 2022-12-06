using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts() 
        {
            var accounts = _context.Accounts.ToList();
            if (accounts is null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }
        [HttpGet("{id:int}", Name = "GetAccount")]
        public ActionResult<Account> GetAccountById(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == id);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpGet("posts")]
        public ActionResult<IEnumerable<Account>> GetAccountsWithPosts() 
        {
            var accounts = _context.Accounts.Include(p => p.Posts).ToList();
            if (accounts is null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount(Account account)
        {
            if (account is null)
            {
                return BadRequest();
            }
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetAccount", new { id = account.AccountId }, account);
        }
    }
}
