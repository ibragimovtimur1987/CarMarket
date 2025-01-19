using AutoFixture;
using AutoMapper;
using Moq;
using Services.Implementations;
using Services.Repositories.Abstractions;
using Xunit;

namespace Services.UnitTests.Services.Implementations
{
    public class ReservationServiceTests
    {
        private readonly IFixture _fixture;

        private readonly Mock<IReservationRepository> _reservationRepository;
        private readonly Mock<IMapper> _mapper;

        private readonly ReservationService _reservationService;

        public ReservationServiceTests()
        {
            _fixture = new Fixture();
            var mockRepository = new MockRepository(MockBehavior.Strict);

            _reservationRepository = mockRepository.Create<IReservationRepository>();
            _mapper = mockRepository.Create<IMapper>();

            _reservationService = new ReservationService(_mapper.Object, _reservationRepository.Object);
        }

        [Fact]
        public async Task ReservationAsync_Success()
        {
            // arrange
            var cancellationToken = CancellationToken.None;
            var request = _fixture.Create<int>();

            _reservationRepository.Setup(x => x.ReservationAsync(request, cancellationToken)).Returns(Task.CompletedTask);
            
            // act
            await _reservationService.ReservationAsync(request, cancellationToken);

            // assert
            _reservationRepository.Verify(x => x.ReservationAsync(request, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
