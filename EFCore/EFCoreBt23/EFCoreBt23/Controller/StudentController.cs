using EFCoreBt23.DTOs;
using EFCoreBt23.Entities;
using EFCoreBt23.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreBt23.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService studentService)
        {
            _service = studentService;
        }

        //GET: api/Users
       [HttpGet]
        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            List<StudentDTO> listStudent = new List<StudentDTO>();
            var students =  await _service.GetStudents();
            foreach (var student in students)
            {
                StudentDTO studentDTO = new StudentDTO()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Birthday = student.Birthday,
                    Gender = student.Gender,
                    Status = student.Status,
                };
                listStudent.Add(studentDTO);
            }
            return listStudent;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<StudentDTO> GetStudentById(int id)
        {
            var result =  await _service.GetStudentById(id);
            StudentDTO student = new StudentDTO() {
                Id = result.Id,
                Name = result.Name,
                Birthday = result.Birthday,
                Gender = result.Gender,
                Status = result.Status
            };
            return student;
        }

        ////// PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<Student> UpdateStudent(int id, StudentDTO studentDTO)
        {
            var student = new Student();
            student.Id = studentDTO.Id;
            student.Name = studentDTO.Name;
            student.Birthday = studentDTO.Birthday;
            student.Gender = studentDTO.Gender;
            student.Status = studentDTO.Status;
            return await _service.UpdateStudent(id, student);
        }

        //// POST: api/Users
        [HttpPost]
        public async Task<Student> AddStudent(StudentDTO studentDTO)
        {
            var student = new Student();
            student.Id = studentDTO.Id;
            student.Name = studentDTO.Name;
            student.Birthday = studentDTO.Birthday;
            student.Gender = studentDTO.Gender;
            student.Status = studentDTO.Status;
            return await _service.AddStudent(student);
        }

        //// DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteStudent(int id)
        {
            return await (_service.DeleteStudent(id));
        }
    }
}
