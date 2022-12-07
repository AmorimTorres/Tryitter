using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;
using Rede_Social_Da_Galera___Tryitter.Repository;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AccountController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts() 
        {
            var accounts = _uow.AccountRepository.GetAll().ToList();
            if (accounts is null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }
        [HttpGet("{id:int}", Name = "GetAccount")]
        public ActionResult<Account> GetAccountById(int id)
        {
            var account = _uow.AccountRepository.GetById(a => a.AccountId == id);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpGet("posts")]
        public ActionResult<IEnumerable<Account>> GetAccountsWithPosts() 
        {
            var accounts = _uow.AccountRepository.GetAccountPosts();
            if (accounts is null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount(Account account)
        {
            _uow.AccountRepository.Add(account);
            _uow.Commit();
            return new CreatedAtRouteResult("GetAccount", new { id = account.AccountId }, account);
        }
        [HttpPut]
        public ActionResult UpdateAccount(int id, Account account)
        {
            if (account.AccountId != id)
            {
                return BadRequest();
            }
            _uow.AccountRepository.Update(account);
            _uow.Commit();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Account> DeleteAccount(int id)
        {
            var account = _uow.AccountRepository.GetById(a => a.AccountId == id);
            if (account is null) 
            {
                return NotFound();
            }
            _uow.AccountRepository.Delete(account);
            _uow.Commit();
            return Ok(account);
        }
    }
}
