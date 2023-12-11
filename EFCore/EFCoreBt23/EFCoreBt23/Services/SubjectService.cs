using EFCoreBt23.Entities;
using EFCoreBt23.Repositories.Interface;
using EFCoreBt23.Services.Interface;

namespace EFCoreBt23.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<Subject> AddSubject(Subject subject)
        {
            var result =  await _subjectRepository.AddSubject(subject);
            return result;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            return await _subjectRepository.DeleteSubject(id);
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await _subjectRepository.GetSubjectById(id);
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _subjectRepository.GetSubjects();
        }

        public async Task<Subject> UpdateSubject(int id, Subject subject)
        {
            return await _subjectRepository.UpdateSubject(id, subject);
        }
    }
}
