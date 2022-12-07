using Rede_Social_Da_Galera___Tryitter.Context;

namespace Rede_Social_Da_Galera___Tryitter.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AccountRepository _accountRepo;
        private StudentRepository _studentRepo;
        private PostRepository _postRepo;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context) 
        {
            _context = context;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                return _studentRepo = _studentRepo ?? new StudentRepository(_context);
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                return _accountRepo = _accountRepo ?? new AccountRepository(_context);
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                return _postRepo = _postRepo ?? new PostRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
