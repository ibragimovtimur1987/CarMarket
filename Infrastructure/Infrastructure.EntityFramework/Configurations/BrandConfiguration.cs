using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasData(
            new Brand
            {
                Id = 1,
                Name = "Toyota"
            },
            new Brand
            {
                Id = 2,
                Name = "Ford"
            },
            new Brand
            {
                Id = 3,
                Name = "BMW"
            }, new Brand
            {
                Id = 4,
                Name = "Honda"
            },
            new Brand
            {
                Id = 5,
                Name = "Chevrolet"
            });
    }
}