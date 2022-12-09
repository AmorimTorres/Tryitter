using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rede_Social_Da_Galera___Tryitter.Context;
using Rede_Social_Da_Galera___Tryitter.DTOS;
using Rede_Social_Da_Galera___Tryitter.Models;
using Rede_Social_Da_Galera___Tryitter.Repository;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = _uow.StudentRepository.GetAll().ToList();
            if (students is null)
            {
                return NotFound("No student was found.");
            }
            var studentsDTO = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentsDTO);
        }

        [HttpGet("{id:int}", Name  = "GetStudent")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _uow.StudentRepository.GetById(s => s.StudentId == id);
            if (student is null)
            {
                return NotFound("No student was found.");
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }
        [HttpGet("posts")]
        public ActionResult<IEnumerable<Student>> GetAccountsWithPosts()
        {
            var students = _uow.StudentRepository.GetStudentsPosts();
            if (students is null)
            {
                return NotFound();
            }
            var studentsDTO = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentsDTO);
        }
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            _uow.StudentRepository.Add(student);
            _uow.Commit();
            return new CreatedAtRouteResult("GetStudent", new { id = student.StudentId }, student);
        }
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

            var studentDTO = _mapper.Map<StudentDTO>(student);

            return Ok(studentDTO);
        }
    }
}
