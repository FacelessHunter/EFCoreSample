using EfCoreSample.Doman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Persistance.EntityConfiguration
{
    class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> departmentBuilder)
        {
            departmentBuilder.ToTable("department", EfCoreSampleDbContext.SchemaName);

            departmentBuilder.HasKey(e => e.Id);

            departmentBuilder.Property(e => e.Name).HasMaxLength(126).IsRequired();
            departmentBuilder.Property(e => e.Location).HasMaxLength(126);

            /*departmentBuilder.HasData(
                new Department()
                {
                    Id = 1,
                    Name = "East",
                    Location = "Ternopil"
                },
                new Department()
                {
                    Id = 1,
                    Name = "West",
                    Location = "Ternopil"
                });*/

        }
    }
}
