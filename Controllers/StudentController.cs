using Microsoft.AspNetCore.Mvc;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = _context.Students.ToList();
            if (students is null)
            {
                return NotFound("No student was found.");
            }
            return Ok(students);
        }

        [HttpGet("{id:int}", Name  = "GetStudent")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student is null)
            {
                return NotFound("No student was found.");
            }
            return Ok(student);
        }
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            if (student is null)
            {
                return BadRequest();
            }
            _context.Students.Add(student);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetStudent", new { id = student.StudentId }, student);
        }
    }
}
