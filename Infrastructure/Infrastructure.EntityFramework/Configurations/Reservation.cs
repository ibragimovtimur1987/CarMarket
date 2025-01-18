using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasData(
            new Reservation
            {
                CarId = 1,
                StartDateUtc = new DateTime(2024, 1, 10),
                EndDateUtc = new DateTime(2024, 1, 20),
            }
        );
    }
}