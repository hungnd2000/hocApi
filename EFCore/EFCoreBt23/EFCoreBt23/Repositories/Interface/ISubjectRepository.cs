using EFCoreBt23.Entities;

namespace EFCoreBt23.Repositories.Interface
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<Subject> AddSubject(Subject subject);
        Task<Subject> UpdateSubject(int id, Subject subject);
        Task<bool> DeleteSubject(int id);
    }
}
