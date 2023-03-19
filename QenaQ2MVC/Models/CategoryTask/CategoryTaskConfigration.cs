using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QenaQ2MVC.Models
{
    public class CategoryTaskConfigration : IEntityTypeConfiguration<CategoryTask>
    {
        public void Configure(EntityTypeBuilder<CategoryTask> builder)
        {
            builder.ToTable("CategoryTask");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(i => i.Name).IsRequired();
                
        }
    }
}
