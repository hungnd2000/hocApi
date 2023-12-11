using EFCoreBt23.Data;
using EFCoreBt23.Entities;
using EFCoreBt23.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBt23.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<MarkRepository> _logger;
        public MarkRepository(StudentDbContext context, ILogger<MarkRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Mark> AddMark(Mark mark)
        {
            try
            {
                if (mark == null)
                {
                    return null;
                }

                _context.marks.Add(mark);
                await _context.SaveChangesAsync();
                return await Task.FromResult(mark);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<bool> DeleteMark(int studentId, int subjectId)
        {
            try
            {
                Mark markDel = await _context.marks.FirstOrDefaultAsync(s => s.StudentId == studentId && s.SubjectId == subjectId);
                if (markDel == null)
                {
                    return true;
                }
                _context.marks.Remove(markDel);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }
        public async Task<IEnumerable<Mark>> GetAllMark()
        {
            try
            {
                return await _context.marks.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task<Mark> UpdateMark(int studentId, int subjectId, Mark mark)
        {
            try
            {
                Mark result = await _context.marks.FirstOrDefaultAsync(s => s.StudentId == studentId && s.SubjectId == subjectId);
                if (result != null)
                {
                    result.StudentId = mark.StudentId; 
                    result.SubjectId = subjectId;
                    result.Scores = mark.Scores;    
                    result.CreateDate = mark.CreateDate;
                }
                _context.Entry(result);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

    }
}
