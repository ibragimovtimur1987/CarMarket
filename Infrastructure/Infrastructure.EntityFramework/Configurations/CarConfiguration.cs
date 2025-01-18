using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(
            new Car
            {
                Id = 1,
                ModelId = 1,
                Vin = "VIN1234567890TOYOTA"
            },
            new Car
            {
                Id = 2,
                ModelId = 2,
                Vin = "VIN1234567890FORD"
            },
            new Car
            {
                Id = 3,
                ModelId = 3,
                Vin = "VIN1234567890BMW"
            }, 
            new Car
            {
                Id = 4,
                ModelId = 4,
                Vin = "VIN1234567890HONDA"
            },
            new Car
            {
                Id = 5,
                ModelId = 5,
                Vin = "VIN1234567890CHEVY"
            });
    }
}