﻿namespace EFCoreBt23.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Scores { get; set; }
        public DateTime CreateDate { get; set; }

        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }
}
