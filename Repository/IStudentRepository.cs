using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetStudentsPosts();
    }
}
