using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configuration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder
                   .Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode();

            builder
               .Property(r => r.Url)
               .IsRequired()
               .IsUnicode(false);
        }
    }
}
