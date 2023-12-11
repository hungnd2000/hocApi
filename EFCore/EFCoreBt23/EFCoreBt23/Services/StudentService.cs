using EFCoreBt23.Entities;
using EFCoreBt23.Repositories.Interface;
using EFCoreBt23.Services.Interface;

namespace EFCoreBt23.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> AddStudent(Student student)
        {
            return await _studentRepository.AddStudent(student);
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _studentRepository.DeleteStudent(id);
        }

        public async Task<Student> GetStudentById(int id)
        {
            var result = await _studentRepository.GetStudentById(id);
            return result;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            return await _studentRepository.UpdateStudent(id, student);
        }
    }
}
