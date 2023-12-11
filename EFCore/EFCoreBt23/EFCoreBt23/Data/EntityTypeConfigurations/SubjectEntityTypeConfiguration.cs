using EFCoreBt23.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBt23.Data.EntityTypeConfigurations
{
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("subject");
            builder.HasKey(b => b.Id).HasName("Tbl_Subject_Pk");
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.Status).HasColumnName("Status");
        }
    }
}
