using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarPriceConfiguration : IEntityTypeConfiguration<CarPrice>
{
    public void Configure(EntityTypeBuilder<CarPrice> builder)
    {
        builder.HasData(
            new CarPrice
            {
              Id = 1,
              CarId = 1,
              Price = 25000,
              StartDateUtc = new DateTime(2024 , 1, 1, 0, 0, 0, DateTimeKind.Utc),
              EndDateUtc = new DateTime(2024 , 2 , 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new CarPrice
            {
                Id = 2,
                CarId = 1,
                Price = 10000,
                StartDateUtc = new DateTime(2024 , 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDateUtc = new DateTime(2024 , 5 , 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new CarPrice
            {
                Id = 3,
                CarId = 2,
                Price = 18000,
                StartDateUtc = new DateTime(2024 , 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDateUtc = new DateTime(2025 , 1 , 1, 0, 0, 0, DateTimeKind.Utc),
            },
            new CarPrice
            {
                Id = 4,
                CarId = 3,
                Price = 55000,
                StartDateUtc = new DateTime(2025 , 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new CarPrice
            {
                Id = 5,
                CarId = 4,
                Price = 25000,
                StartDateUtc = new DateTime(2025 , 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new CarPrice
            {
                Id = 6,
                CarId = 5,
                Price = 25000,
                StartDateUtc = new DateTime(2025 , 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });
    }
}