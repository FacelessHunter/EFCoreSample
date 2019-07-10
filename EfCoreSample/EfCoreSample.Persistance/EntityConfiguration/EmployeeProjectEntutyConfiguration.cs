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
            employeeProjectBuilder.HasData(
                new EmployeeProject()
                {
                    EmployeeId = 1,
                    ProjectId = 1
                },
                new EmployeeProject()
                {
                    EmployeeId = 1,
                    ProjectId = 2
                },
                new EmployeeProject()
                {
                    EmployeeId = 1,
                    ProjectId = 3
                },
                new EmployeeProject()
                {
                    EmployeeId = 6,
                    ProjectId = 4
                },
                new EmployeeProject()
                {
                    EmployeeId = 2,
                    ProjectId = 1
                },
                new EmployeeProject()
                {
                    EmployeeId = 2,
                    ProjectId = 2
                },
                new EmployeeProject()
                {
                    EmployeeId = 2,
                    ProjectId = 3
                },
                new EmployeeProject()
                {
                    EmployeeId = 5,
                    ProjectId = 4
                },
                new EmployeeProject()
                {
                    EmployeeId = 3,
                    ProjectId = 1
                },
                new EmployeeProject()
                {
                    EmployeeId = 3,
                    ProjectId = 2
                },
                new EmployeeProject()
                {
                    EmployeeId = 3,
                    ProjectId = 3
                },
                new EmployeeProject()
                {
                    EmployeeId = 3,
                    ProjectId = 4
                });


        }
    }
}
