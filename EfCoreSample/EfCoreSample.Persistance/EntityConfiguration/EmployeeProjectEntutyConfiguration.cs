using EfCoreSample.Doman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Persistance.EntityConfiguration
{
    class EmployeeProjectEntutyConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> employeeProjectBuilder)
        {
            employeeProjectBuilder.HasKey(ed => new { ed.EmployeeId, ed.ProjectId });

            employeeProjectBuilder
                .HasOne(ed => ed.Project)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ed => ed.ProjectId);

            employeeProjectBuilder
                .HasOne(ed => ed.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ed => ed.EmployeeId);
        }
    }
}
