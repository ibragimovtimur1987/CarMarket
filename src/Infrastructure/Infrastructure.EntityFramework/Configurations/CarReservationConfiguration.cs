﻿using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarReservationConfiguration : IEntityTypeConfiguration<CarReservation>
{
    public void Configure(EntityTypeBuilder<CarReservation> builder)
    {
        builder.HasData(
            new CarReservation
            {
                Id = 1,
                CarId = 1,
                StartDateUtc = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc ),
                EndDateUtc = new DateTime(2024, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                ReservedAtUtc = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc),
            }
        );
    }
}