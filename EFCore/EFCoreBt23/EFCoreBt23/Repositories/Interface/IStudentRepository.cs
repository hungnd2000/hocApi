using EFCoreBt23.Entities;

namespace EFCoreBt23.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(int id, Student student);
        Task<bool> DeleteStudent(int id);
    }
}
