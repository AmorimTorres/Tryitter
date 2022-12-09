using System.ComponentModel.DataAnnotations;

namespace Rede_Social_Da_Galera___Tryitter.DTOS
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
        public string? CourseModule { get; set; }
        public string? Status { get; set; }
    }
}
