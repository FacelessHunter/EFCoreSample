using EfCoreSample.Persistance.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSample.Persistance
{
    public class EfCoreSampleDbContext : DbContext
    {
        public const string SchemaName = "efcoresample";

        public EfCoreSampleDbContext(DbContextOptions<EfCoreSampleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AddressEntityConfiguration());
            builder.ApplyConfiguration(new EmployeeDepartmentEntityConfiguration());
            builder.ApplyConfiguration(new EmployeeEntityConfiguration());
        }
    }
}
