using EFCoreBt23.DTOs;
using EFCoreBt23.Entities;
using EFCoreBt23.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreBt23.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<SubjectDTO>> GetSubjects()
        {
            var result = await _service.GetSubjects();
            List<SubjectDTO> subjectDTOs = new List<SubjectDTO>();

            foreach (var subject in result)
            {
                SubjectDTO subjectDTO = new SubjectDTO() { Id = subject.Id, Name = subject.Name, Status = subject.Status};
                subjectDTOs.Add(subjectDTO);    
            }
            return subjectDTOs;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<SubjectDTO> GetSubjectById(int id)
        {
            var result = await _service.GetSubjectById(id);
            return new SubjectDTO() { Id = result.Id,Name =  result.Name, Status = result.Status};  
        }

        //// PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<Subject> UpdateSubject(int id, SubjectDTO subject)
        {
            var subjectInput = new Subject() { Id = subject.Id, Name = subject.Name, Status = subject.Status };
            return await _service.UpdateSubject(id, subjectInput);
        }

        //// POST: api/Users
        [HttpPost]
        public async Task<Subject> AddStudent(SubjectDTO subject)
        {
            var subjectInput = new Subject() { Id = subject.Id, Name = subject.Name, Status = subject.Status};
            return await _service.AddSubject(subjectInput);
        }

        //// DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteSubjectt(int id)
        {
            return await (_service.DeleteSubject(id));
        }
    }
}
