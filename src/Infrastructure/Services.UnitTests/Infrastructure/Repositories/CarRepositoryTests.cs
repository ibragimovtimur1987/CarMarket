using AutoFixture;
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
        var actualResult = await _handler.SearchAsync(query, CancellationToken.None);

        // assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
}