using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Services.Contracts.Models.Car.Search;
using Services.Implementations;
using Services.Repositories.Abstractions;
using Xunit;

namespace Services.UnitTests.Services.Implementations
{
    public class CarServiceTests
    {
        private readonly IFixture _fixture;

        private readonly Mock<ICarRepository> _carRepository;
        private readonly Mock<IMapper> _mapper;

        private readonly CarService _service;

        public CarServiceTests()
        {
            _fixture = new Fixture();
            var mockRepository = new MockRepository(MockBehavior.Strict);

            _carRepository = mockRepository.Create<ICarRepository>();
            _mapper = mockRepository.Create<IMapper>();

            _service = new CarService(_mapper.Object, _carRepository.Object);
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            // arrange
            var cancellationToken = CancellationToken.None;
            var query = _fixture.Create<SearchCarsQueryModel>();
            var expectedResponse = _fixture.Create<List<SearchCarsResultModel>>();
            
            _carRepository.Setup(x => x.SearchAsync(query, cancellationToken)).ReturnsAsync(expectedResponse);

            // act
            var actualResult =  await _service.SearchAsync(query, CancellationToken.None);

            // assert
            actualResult.Should().BeEquivalentTo(expectedResponse);

            _carRepository.Verify(x => x.SearchAsync(query, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
