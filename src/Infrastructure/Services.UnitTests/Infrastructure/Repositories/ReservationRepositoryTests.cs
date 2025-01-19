using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Repositories.Implementations;
using Services.UnitTests.Infrastructure.EntityFramework;
using Xunit;

namespace Services.UnitTests.Infrastructure.Repositories;

public class ReservationRepositoryTests
{
    private readonly IFixture _fixture;

    private readonly ReservationRepository _handler;
    private readonly TestCarMarketDbContext _context;

    public ReservationRepositoryTests()
    {
        _fixture = new Fixture();
        _context = new TestCarMarketDbContext();
        _handler = new ReservationRepository(_context);
    }

    [Fact]
    public async Task HandleReservationAsync_Sucess()
    {
        // Arrange
        var carId = 3;
        
        var expectedResult = new CarReservation
        {
            CarId = carId,
        };
        
        // Act
        await _handler.ReservationAsync(carId, CancellationToken.None);

        var actualResult = _context.CarReservation.FirstOrDefault(cr => cr.CarId == carId);
        
        // assert
        actualResult.CarId.Equals(expectedResult.CarId);
    }

    [Fact]
    public async Task HandleReservationAsync_NotFoundCar_Failure()
    {
        // Arrange
        var carId = 6;
        
        // act
        Func<Task> function = () => _handler.ReservationAsync(carId, CancellationToken.None);

        // assert
        await function.Should()
            .ThrowExactlyAsync<System.Exception>();
    }
    
    [Fact]
    public async Task HandleReservationAsync_IsReserved_Failure()
    {
        // Arrange
        var carId = 1;
        
        // act
        Func<Task> function = () => _handler.ReservationAsync(carId, CancellationToken.None);

        // assert
        await function.Should()
            .ThrowExactlyAsync<System.Exception>();
    }
}