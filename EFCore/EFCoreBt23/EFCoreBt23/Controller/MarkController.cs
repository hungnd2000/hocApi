using EFCoreBt23.DTOs;
using EFCoreBt23.Entities;
using EFCoreBt23.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreBt23.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _service;
        public MarkController(IMarkService markService)
        {
            _service = markService;
        }

        [HttpGet]
        public async Task<IEnumerable<MarkDTO>> GetMarks()
        {
            List<MarkDTO> listMark = new List<MarkDTO>();
            var marks = await _service.GetMarks();
            foreach (var mark in marks)
            {
                MarkDTO markDTO = new MarkDTO()
                {
                    Id = mark.Id,
                    StudentId = mark.StudentId,
                    SubjectId = mark.SubjectId,
                    Scores = mark.Scores,
                    CreateDate = mark.CreateDate,
                };
                listMark.Add(markDTO);
            }
            return listMark;
        }

        ////// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public async Task<Student> UpdateStudent(int id, StudentDTO studentDTO)
        //{
        //    var student = new Student();
        //    student.Id = studentDTO.Id;
        //    student.Name = studentDTO.Name;
        //    student.Birthday = studentDTO.Birthday;
        //    student.Gender = studentDTO.Gender;
        //    student.Status = studentDTO.Status;
        //    return await _service.UpdateStudent(id, student);
        //}

        //// POST: api/Users
        [HttpPost]
        public async Task<Mark> AddStudent(MarkDTO markDTO)
        {
            var markInput = new Mark() {
                Id = markDTO.Id,
                StudentId = markDTO.StudentId, 
                SubjectId = markDTO.SubjectId, 
                Scores = markDTO.Scores, 
                CreateDate = markDTO.CreateDate
            };
            return await _service.AddMark(markInput);
        }

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<bool> DeleteStudent(int id)
        //{
        //    return await (_service.DeleteStudent(id));
        //}
    }
}
