using EFCoreBt23.Entities;

namespace EFCoreBt23.Repositories.Interface
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Mark>> GetAllMark();
        Task<Mark> AddMark(Mark mark);
        Task<Mark> UpdateMark(int studentId, int subjectId, Mark mark);
        Task<bool> DeleteMark(int studentId, int subjectId);
    }
}
