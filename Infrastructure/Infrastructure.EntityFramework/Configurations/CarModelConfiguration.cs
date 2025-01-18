using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.HasMany(b => b.Cars).WithOne(r => r.Model).HasForeignKey(r => r.ModelId);
        builder.Property(p => p.Name).HasMaxLength(4000);
        
        builder.HasData(
            new CarModel
            {
                Id = 1,
                BrandId = 1,
                Name = "Corolla"
            },
            new CarModel
            {
                Id = 2,
                BrandId = 2,
                Name = "Focus"
            },
            new CarModel
            {
                Id = 3,
                BrandId = 3,
                Name = "X5"
            }, new CarModel
            {
                Id = 4,
                BrandId = 1,
                Name = "Camry"
            },
            new CarModel
            {
                Id = 5,
                BrandId = 4,
                Name = "Civic"
            },
            new CarModel
            {
                Id = 6,  
                BrandId = 5,
                Name = "Malibu"
            });
    }
}