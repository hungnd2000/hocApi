using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreBt23.DTOs
{
    public class MarkDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Scores { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
