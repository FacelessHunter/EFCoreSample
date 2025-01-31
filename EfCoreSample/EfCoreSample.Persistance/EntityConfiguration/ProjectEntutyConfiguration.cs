﻿using EfCoreSample.Doman;
using EfCoreSample.Doman.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSample.Persistance.EntityConfiguration
{
    class ProjectEntutyConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> projectBuilder)
        {
            projectBuilder.ToTable("project", EfCoreSampleDbContext.SchemaName);

            projectBuilder.HasKey(e => e.Id);
           
            projectBuilder.Property(e => e.Title).HasMaxLength(30).IsRequired();
            projectBuilder.Property(e => e.Description).HasMaxLength(256);
            projectBuilder.Property(e => e.Status).IsRequired();

            projectBuilder.Property(e => e.StartTime)
                .HasDefaultValueSql("current_timestamp(6)");

            projectBuilder.Property(t => t.LastUpdatedTime)
                .HasDefaultValueSql("current_timestamp(6) ON UPDATE current_timestamp(6)")
                .ValueGeneratedOnAddOrUpdate();
            projectBuilder.HasData(
                new Project()
                {
                    Id = 1,
                    Title = "Rakta",
                    Status = Status.Cancelled
                },
                new Project()
                {
                    Id = 2,
                    Title = "WWW",
                    Status = Status.Pending
                },
                new Project()
                {
                    Id = 3,
                    Title = "FairyTail",
                    Status = Status.InProgress
                }, new Project()
                {
                    Id = 4,
                    Title = "Windows lite",
                    Status = Status.InProgress
                }, new Project()
                {
                    Id = 5,
                    Title = "GTA4",
                    Status = Status.Completed
                }); ; 

        }
    }
}
