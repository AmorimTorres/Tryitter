using System.ComponentModel.DataAnnotations;

namespace Rede_Social_Da_Galera___Tryitter.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set;}
        [Required]
        public string? StudentEmail { get; set; }
        public string? CourseModule { get; set; }
        public string? Status { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
