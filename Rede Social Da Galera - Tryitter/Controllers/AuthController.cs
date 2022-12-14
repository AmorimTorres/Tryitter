using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rede_Social_Da_Galera___Tryitter.AuthModels;
using Rede_Social_Da_Galera___Tryitter.DTOS;
using Rede_Social_Da_Galera___Tryitter.Models;
using Rede_Social_Da_Galera___Tryitter.Repository;
using Rede_Social_Da_Galera___Tryitter.Services;

namespace Rede_Social_Da_Galera___Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AuthController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<StudentViewModel>> Authenticate(Student student)
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            try
            {
                var getStudent = await _uow.StudentRepository.GetById(s => s.StudentId == student.StudentId);
                if (getStudent is null)
                {
                    return NotFound("No student was found.");
                }

                var studentDTO = _mapper.Map<StudentDTO>(getStudent);

                studentViewModel.Token = new TokenGenerator().Generate(student);

                studentViewModel.Student = studentDTO;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return studentViewModel;
        }
    }
}
