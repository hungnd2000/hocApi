using EFCoreBt23.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace EFCoreBt23.Data.EntityTypeConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("student"); 
            builder.HasKey(b => b.Id).HasName("Tbl_Student_Pk");
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.Birthday).HasColumnName("Birthday");
            builder.Property(b => b.Gender).HasColumnName("Gender");
            builder.Property(b => b.Status).HasColumnName("Status");
        }
    }
}
