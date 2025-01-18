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
                ModelId = 1,
                Vin = "VIN1234567890TOYOTA"
            },
            new Car
            {
                ModelId = 2,
                Vin = "VIN1234567890FORD"
            },
            new Car
            {
                ModelId = 3,
                Vin = "VIN1234567890BMW"
            }, 
            new Car
            {
                ModelId = 4,
                Vin = "VIN1234567890HONDA"
            },
            new Car
            {
                ModelId = 5,
                Vin = "VIN1234567890CHEVY"
            });
    }
}