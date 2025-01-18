using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
{
    public void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(4000);
        builder.HasData(
            new CarBrand
            {
                Id = 1,
                Name = "Toyota"
            },
            new CarBrand
            {
                Id = 2,
                Name = "Ford"
            },
            new CarBrand
            {
                Id = 3,
                Name = "BMW"
            }, new CarBrand
            {
                Id = 4,
                Name = "Honda"
            },
            new CarBrand
            {
                Id = 5,
                Name = "Chevrolet"
            });
    }
}