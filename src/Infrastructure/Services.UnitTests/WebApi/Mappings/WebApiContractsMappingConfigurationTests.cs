using AutoMapper;
using WebApi.Mapping;
using Xunit;

namespace Services.UnitTests.WebApi.Mappings
{
    public class WebApiContractsMappingConfigurationTests
    {
        private readonly IMapper _mapper;

        public WebApiContractsMappingConfigurationTests()
        {
        }

        [Fact]
        public void AssertConfigurationIsValid_Success()
        {
            // arrange & act & assert
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarMappingsProfile>();
            });
            configuration.AssertConfigurationIsValid();
        }
    }
}