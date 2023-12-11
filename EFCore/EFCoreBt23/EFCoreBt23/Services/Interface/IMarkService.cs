using EFCoreBt23.Entities;

namespace EFCoreBt23.Services.Interface
{
    public interface IMarkService
    {
        Task<IEnumerable<Mark>> GetMarks();
        Task<Mark> AddMark(Mark mark);
        Task<Mark> UpdateMark(int StudentId, int SubjectId, Mark mark);
        Task<bool> DeleteMark(int StudentId, int SubjectId);
    }
}
