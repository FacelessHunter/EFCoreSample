using EfCoreSample.Doman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Persistance.EntityConfiguration
{
    class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> addressBuilder)
        {
            addressBuilder.ToTable("address", EfCoreSampleDbContext.SchemaName);

            addressBuilder.HasKey(a => a.Id);

            addressBuilder
                .HasOne(a => a.Employee)
                .WithMany(e => e.Addresses)
                .HasForeignKey(a => a.EmployeeId);

            addressBuilder.HasIndex(a =>
            new
            {
                a.City,
                a.Country,
                a.Street
            }).ForMySqlIsFullText();

            addressBuilder.HasData(
                new Address()
                {
                    Id = 1,
                    Street = "Bohdana Khmel`nyts`koho St, 52",
                    City = "Kyiv",
                    Country = "Ukraine",
                    EmployeeId = 1
                },
                new Address()
                {
                    Id = 2,
                    Street = "Les Kurbas, 2a",
                    City = "Ternopil",
                    Country = "Ukraine",
                    EmployeeId = 2
                },
                new Address()
                {
                    Id = 3,
                    Street = "Gnatyuk, 12a",
                    City = "Lviv",
                    Country = "Ukraine",
                    EmployeeId = 1
                },
                 new Address()
                {
                    Id = 4,
                    Street = "",
                    City = "Hague",
                    Country = "Netherlands",
                    EmployeeId = 1
                });
        }
    }
}
