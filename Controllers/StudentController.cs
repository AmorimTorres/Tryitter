using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.Models;
using Rede_Social_Da_Galera___Tryitter.Repository;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public StudentController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = _uow.StudentRepository.GetAll().ToList();
            if (students is null)
            {
                return NotFound("No student was found.");
            }
            return Ok(students);
        }

        [HttpGet("{id:int}", Name  = "GetStudent")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _uow.StudentRepository.GetById(s => s.StudentId == id);
            if (student is null)
            {
                return NotFound("No student was found.");
            }
            return Ok(student);
        }
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            _uow.StudentRepository.Add(student);
            _uow.Commit();
            return new CreatedAtRouteResult("GetStudent", new { id = student.StudentId }, student);
        }

        //[HttpPost("authenticate")]
        //public ActionResult<Student> Authenticate(Student student)
        //{
        //    UserViewModel userViewModel = new UserViewModel();
        //    try
        //    {
        //        student.Password = new TokenGenerator().Generate();


 
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return userViewModel;
        //}

        [HttpPut]
        public ActionResult UpdateStudent(int id, Student student)
        {
            if (student.StudentId != id)
            {
                return BadRequest();
            }
            _uow.StudentRepository.Update(student);
            _uow.Commit();

            return NoContent();
        }
        [HttpDelete]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = _uow.StudentRepository.GetById(s => s.StudentId == id);
            if (student is null)
            {
                return NotFound("No student was found.");
            }
            _uow.StudentRepository.Delete(student);
            _uow.Commit();

            return Ok(student);
        }
    }
}
