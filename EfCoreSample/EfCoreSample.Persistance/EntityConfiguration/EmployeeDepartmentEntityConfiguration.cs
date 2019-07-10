using EfCoreSample.Doman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Persistance.EntityConfiguration
{
    class EmployeeDepartmentEntityConfiguration : IEntityTypeConfiguration<EmployeeDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartment> employeeDepartmentBuilder)
        {
            employeeDepartmentBuilder.HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

            employeeDepartmentBuilder
                .HasOne(ed => ed.Department)
                .WithMany(e => e.EmployeeDepartments)
                .HasForeignKey(ed => ed.DepartmentId);

            employeeDepartmentBuilder
                .HasOne(ed => ed.Employee)
                .WithMany(e => e.EmployeeDepartments)
                .HasForeignKey(ed => ed.EmployeeId);

            employeeDepartmentBuilder.HasData(
                new EmployeeDepartment()
                {
                    EmployeeId = 1,
                    DepartmentId = 1
                },
                new EmployeeDepartment()
                {
                    EmployeeId = 1,
                    DepartmentId = 2
                },
                new EmployeeDepartment()
                {
                    EmployeeId = 3,
                    DepartmentId = 3
                },
                new EmployeeDepartment()
                {
                    EmployeeId = 4,
                    DepartmentId = 1
                });
        }
    }
}
