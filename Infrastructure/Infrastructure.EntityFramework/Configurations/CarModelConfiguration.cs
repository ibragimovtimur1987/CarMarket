using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.HasData(
            new CarModel
            {
                BrandId = 1,
                Name = "Corolla"
            },
            new CarModel
            {
                BrandId = 2,
                Name = "Focus"
            },
            new CarModel
            {
                BrandId = 3,
                Name = "X5"
            }, new CarModel
            {
                BrandId = 1,
                Name = "Camry"
            },
            new CarModel
            {
                BrandId = 4,
                Name = "Civic"
            },
            new CarModel
            {
                BrandId = 5,
                Name = "Malibu"
            });
    }
}