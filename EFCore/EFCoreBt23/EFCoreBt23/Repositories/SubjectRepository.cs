using EFCoreBt23.Data;
using EFCoreBt23.Entities;
using EFCoreBt23.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBt23.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<SubjectRepository> _logger;

        public SubjectRepository(StudentDbContext context, ILogger<SubjectRepository> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    return null;
                }
                _context.subjects.Add(subject);
                await _context.SaveChangesAsync();
                return subject;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }



        public async Task<bool> DeleteSubject(int id)
        {
            try
            {
                Subject subjectDel = await _context.subjects.FindAsync(id);
                if (subjectDel == null)
                {
                    return true;
                }
                _context.subjects.Remove(subjectDel);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                return await _context.subjects.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            try
            {
                return await _context.subjects.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<Subject> UpdateSubject(int id, Subject subject)
        {
            try
            {
                Subject subjectEdit = await _context.subjects.FindAsync(id);
                if (id == subjectEdit.Id)
                {
                    subjectEdit.Name = subject.Name;
                    subjectEdit.Status = subject.Status;
                }
                _context.Entry(subjectEdit);
                await _context.SaveChangesAsync();
                return subjectEdit;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

    }
}
