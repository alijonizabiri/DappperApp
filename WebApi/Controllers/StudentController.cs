using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController
    {
        private StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }


        [HttpGet]
        public List<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }

        [HttpPost("Insert")]
        public int InsertStudent(Student student)
        {
            return _studentService.InsertStudent(student);
        }

        [HttpPut]
        public int UpdateStudent(Student student)
        {
            return _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        public int DeleteStudent(int id)
        {
            return _studentService.DeleteStudent(id);
        }
    }
}
