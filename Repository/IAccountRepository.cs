using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetAccountPosts();
    }
}
