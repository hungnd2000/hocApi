using EFCoreBt23.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBt23.Data.EntityTypeConfigurations
{
    public class MarkEntityTypeConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable("mark");

            builder.HasKey(b => b.Id).HasName("PK_StudentSubject");
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.StudentId).HasColumnName("StudentId");
            builder.Property(b => b.SubjectId).HasColumnName("SubjectId");
            builder.Property(b => b.Scores).HasColumnName("Scores");
            builder.Property(b => b.CreateDate).HasColumnName("CreateDate");

            builder.HasOne(m => m.Student)
                   .WithMany(s => s.Marks)
                   .HasForeignKey(m => m.StudentId);

            builder.HasOne(m => m.Subject)
                   .WithMany(s => s.Marks)
                   .HasForeignKey(m => m.SubjectId);
        }
    }
}
