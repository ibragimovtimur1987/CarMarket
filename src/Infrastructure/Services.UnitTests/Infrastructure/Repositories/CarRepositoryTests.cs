using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.Models.Car.Search;
using Services.UnitTests.Infrastructure.EntityFramework;
using Xunit;

namespace Services.UnitTests.Infrastructure.Repositories;

public class CarRepositoryTests
{
    private readonly IFixture _fixture;

    private readonly CarRepository _handler;
    private readonly TestCarMarketDbContext _context;

    public CarRepositoryTests()
    {
        _fixture = new Fixture();
        _context = new TestCarMarketDbContext();
        Seed();
        _handler = new CarRepository(_context);
    }

    [Fact]
    public async Task HandleSearchAsync_Sucess()
    {
        // Arrange
        var query = new SearchCarsQueryModel
        {
            AvailabilityDateUtc = DateTime.UtcNow
        };

        var expectedResult = await _context.Car
            .Where(car => car.Reservations
                .All(res => res.StartDateUtc > query.AvailabilityDateUtc ||
                            res.EndDateUtc < query.AvailabilityDateUtc))
            .Where(car => car.CarPrices
                .Any(p => query.AvailabilityDateUtc > p.StartDateUtc &&
                          (p.EndDateUtc == null || query.AvailabilityDateUtc < p.EndDateUtc)))
            .Select(car => new SearchCarsResultModel
            {
                CarId = car.Id,
                Price = car.CarPrices.Select(p => p.Price).First(),
                Brand = car.Model.CarBrand.Name,
                Model = car.Model.Name,
            })
            .ToListAsync();

        // Act
        var actualResult = await _handler.SearchAsync(query);

        // assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    private void Seed()
    {
        var brands = new List<CarBrand>
        {
            new CarBrand { Name = "Toyota" },
            new CarBrand { Name = "Ford" },
            new CarBrand { Name = "BMW" }
        };

        _context.CarBrand.AddRange(brands);
        _context.SaveChanges();

        var models = new List<CarModel>
        {
            new CarModel { BrandId = brands[0].Id, Name = "Camry" },
            new CarModel { BrandId = brands[0].Id, Name = "Corolla" },
            new CarModel { BrandId = brands[1].Id, Name = "Mustang" },
            new CarModel { BrandId = brands[2].Id, Name = "X5" }
        };

        _context.CarModel.AddRange(models);
        _context.SaveChanges();

        var cars = new List<Car>
        {
            new Car { ModelId = models[0].Id },
            new Car { ModelId = models[1].Id },
            new Car { ModelId = models[2].Id },
            new Car { ModelId = models[3].Id }
        };

        _context.Car.AddRange(cars);

        _context.SaveChanges();

        var priceHistories = new List<CarPrice>
        {
            new CarPrice
            {
                CarId = cars[0].Id, Price = 30000, StartDateUtc = DateTime.Now.AddDays(-10),
                EndDateUtc = DateTime.Now.AddDays(10)
            },
            new CarPrice
            {
                CarId = cars[1].Id, Price = 20000, StartDateUtc = DateTime.Now.AddDays(-5),
                EndDateUtc = DateTime.Now.AddDays(15)
            },
            new CarPrice
            {
                CarId = cars[2].Id, Price = 50000, StartDateUtc = DateTime.Now.AddDays(-20),
                EndDateUtc = DateTime.Now.AddDays(5)
            },
            new CarPrice { CarId = cars[3].Id, Price = 70000, StartDateUtc = DateTime.Now.AddDays(-30) }
        };

        _context.CarPrice.AddRange(priceHistories);
        _context.SaveChanges();

        var reservations = new List<CarReservation>
        {
            new CarReservation
            {
                CarId = cars[0].Id, StartDateUtc = DateTime.UtcNow, EndDateUtc = DateTime.Now.AddDays(10),
                ReservedAtUtc = DateTime.UtcNow
            },
            new CarReservation
            {
                CarId = cars[1].Id, StartDateUtc = DateTime.UtcNow.AddDays(20), EndDateUtc = DateTime.Now.AddDays(30),
                ReservedAtUtc = DateTime.UtcNow.AddDays(10)
            }
        };

        _context.CarReservation.AddRange(reservations);
        _context.SaveChanges();
    }
}