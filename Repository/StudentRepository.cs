using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> GetStudentsPosts()
        {
            return await GetAll().Include(p => p.Posts).ToListAsync();
        }
    }
}
