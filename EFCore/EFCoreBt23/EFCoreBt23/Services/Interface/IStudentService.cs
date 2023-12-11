using EFCoreBt23.Entities;

namespace EFCoreBt23.Services.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(int id, Student student);
        Task<bool> DeleteStudent(int id);
    }
}
