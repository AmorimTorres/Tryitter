using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<Account> GetAccountPosts()
        {
            return GetAll().Include(p => p.Posts);
        }
    }
}
