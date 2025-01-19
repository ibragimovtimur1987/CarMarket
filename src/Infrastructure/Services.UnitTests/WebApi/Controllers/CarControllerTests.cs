using AutoFixture;
using AutoMapper;
using FluentAssertions;
using MassTransit.Mediator;
using Moq;
using Services.Abstractions;
using Services.Contracts.Models.Car.Search;
using WebApi.Controllers;
using WebApi.Models.Car.Search;
using Xunit;

namespace Services.UnitTests.WebApi.Controllers
{
    public class CarControllerTests
    {
        private readonly IFixture _fixture;

        private readonly Mock<ICarService> _carService;
        private readonly Mock<IReservationService> _reservationService;
        private readonly Mock<IMapper> _mapper;

        private readonly CarController _controller;

        public CarControllerTests()
        {
            _fixture = new Fixture();
            var mockRepository = new MockRepository(MockBehavior.Strict);

            _carService = mockRepository.Create<ICarService>();
            _reservationService= mockRepository.Create<IReservationService>();
            _mapper = mockRepository.Create<IMapper>();

            _controller = new CarController(_carService.Object, _mapper.Object, _reservationService.Object);
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            // arrange
            var cancellationToken = CancellationToken.None;
            var request = _fixture.Create<SearchCarsRequestModel>();
            var query = _fixture.Create<SearchCarsQueryModel>();
            var queryResult = _fixture.Create<List<SearchCarsResultModel>>();
            
            var expectedResponse = _fixture
                .Build<List<SearchCarsResponseModel>>()
                .Create();

            _mapper.Setup(x =>
                x.Map<SearchCarsQueryModel>(
                    request)).Returns(query);
            
            _carService.Setup(x => x.SearchAsync(query, cancellationToken)).ReturnsAsync(queryResult);

            _mapper.Setup(x =>
                x.Map<List<SearchCarsResponseModel>>(
                    queryResult)).Returns(expectedResponse);
            // act
            var actualResult =  await _controller.SearchAsync(request, CancellationToken.None);

            // assert
            actualResult.Value.Should().BeEquivalentTo(expectedResponse);

            _carService.Verify(x => x.SearchAsync(query, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ReservationAsync_Success()
        {
            // arrange
            var cancellationToken = CancellationToken.None;
            var request = _fixture.Create<int>();

            _reservationService.Setup(x => x.ReservationAsync(request, cancellationToken)).Returns(Task.CompletedTask);
            
            // act
            await _controller.ReservationAsync(request, cancellationToken);

            // assert
            _reservationService.Verify(x => x.ReservationAsync(request, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
