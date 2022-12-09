namespace Rede_Social_Da_Galera___Tryitter.Repository
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        IPostRepository PostRepository { get; }
        Task Commit();
    }
}
