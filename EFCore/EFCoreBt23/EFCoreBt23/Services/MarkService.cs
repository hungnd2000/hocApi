using EFCoreBt23.Entities;
using EFCoreBt23.Repositories.Interface;
using EFCoreBt23.Services.Interface;

namespace EFCoreBt23.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        public MarkService(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }
        public Task<Mark> AddMark(Mark mark)
        {
            return _markRepository.AddMark(mark);
        }

        public Task<bool> DeleteMark(int StudentId, int SubjectId)
        {
            return (_markRepository.DeleteMark(StudentId, SubjectId));
        }

        public Task<IEnumerable<Mark>> GetMarks()
        {
            return _markRepository.GetAllMark();
        }

        public Task<Mark> UpdateMark(int StudentId, int SubjectId, Mark subject)
        {
            return _markRepository.UpdateMark(StudentId, SubjectId, subject);
        }
    }
}
