using EFCoreBt23.Data;
using EFCoreBt23.Entities;
using EFCoreBt23.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBt23.Repos
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<StudentRepository> _logger;
        public StudentRepository(StudentDbContext context, ILogger<StudentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return null;
                }
                
                _context.students.Add(student);
                await _context.SaveChangesAsync();
                return await Task.FromResult(new Student());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                Student studentDel = await _context.students.FindAsync(id);
                if (studentDel == null)
                {
                    return true;
                }
                _context.students.Remove(studentDel);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                return await _context.students.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return await _context.students.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            try
            {
                Student student1 = await _context.students.FindAsync(id);
                if (id == student1.Id)
                {
                    student1.Name = student.Name;
                    student1.Birthday = student.Birthday;
                    student1.Gender = student.Gender;
                    student1.Status = student.Status;
                }
                _context.Entry(student1);
                await _context.SaveChangesAsync();
                return student1;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }
    }
}
