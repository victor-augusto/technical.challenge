using AutoMapper;
using Moq;
using System.Threading.Tasks;
using va.technical.challenge.domain.Dtos.Divisor;
using va.technical.challenge.domain.Interfaces;
using va.technical.challenge.services;
using va.technical.challenge.tests.Fixture;
using Xunit;

namespace va.technical.challenge.tests.Services
{
    [Collection(nameof(DivisorFixtureCollection))]
    public class DivisorPrimoServiceTests
    {
        private readonly DivisorFixture _fixture;
        private readonly DivisorPrimoService _service;

        public DivisorPrimoServiceTests(DivisorFixture fixture)
        {
            _fixture = fixture;
            _service = _fixture.GetDivisorPrimoInstance();
        }

        [Trait("services", nameof(DivisorService))]
        [Theory(DisplayName = "Obter Divisores Primos - Sucesso")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ObterDivisoresPrimosAsync_Sucesso(bool isNull)
        {
            // Arrange
            var divisorPrimoRequest = _fixture.GetDivisorPrimoRequest();
            var divisorPrimoResponse = _fixture.GetDivisorPrimoResponse(isNull);

            _fixture.Mocker.GetMock<IDivisorPrimoService>().Setup(x => x.ObterDivisoresPrimosAsync(It.IsAny<DivisorPrimoRequest>())).ReturnsAsync(divisorPrimoResponse);
            _fixture.Mocker.GetMock<IMapper>().SetReturnsDefault(divisorPrimoResponse);

            // Act
            var result = await _service.ObterDivisoresPrimosAsync(divisorPrimoRequest);

            // Assert
            Assert.NotNull(result);

            if (isNull)
                Assert.Equal(0, result.DivisoresPrimos.Count);
            else
                Assert.True(result.DivisoresPrimos.Count > 0);
        }
    }
}
