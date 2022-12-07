namespace Rede_Social_Da_Galera___Tryitter.Repository
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        IAccountRepository AccountRepository { get; }
        IPostRepository PostRepository { get; }
        void Commit();
    }
}
