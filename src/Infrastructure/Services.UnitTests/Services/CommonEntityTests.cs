using System.Collections;
using System.Reflection;
using Domain.Entities;
using FluentAssertions;
using Services.Contracts.Models.Car.Search;
using Xunit;

namespace Services.UnitTests.Services
{
    public class CommonEntityTests
    {
        private const string EntitiesNamespace = "Services.Contracts.Models.Car.Search";
        private readonly List<Type> _types;

        public CommonEntityTests()
        {
            _types = typeof(SearchCarsQueryModel).Assembly
                .GetTypes()
                .Where(x => x.IsClass
                            && x.FullName.StartsWith(EntitiesNamespace)
                            && x.GetConstructor(Type.EmptyTypes) is not null)
                .ToList();
        }

        [Fact]
        public void Constructor_PropertyCollections_Success()
        {
            // arrange & act & assert
            foreach (var type in _types)
            {
                var properties = type
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.PropertyType != typeof(string)
                        && x.PropertyType.IsAssignableTo(typeof(IEnumerable)))
                    .ToList();

                var entity = Activator.CreateInstance(type);

                foreach (var property in properties)
                {
                    property.GetValue(entity).Should().NotBeNull();
                }
            }
        }
    }
}
