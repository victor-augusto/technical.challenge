using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using va.technical.challenge.domain.Dtos.Divisor;
using va.technical.challenge.domain.Interfaces;
using va.technical.challenge.services;
using va.technical.challenge.tests.Fixture;
using Xunit;

namespace va.technical.challenge.tests.Services
{
    [Collection(nameof(DivisorFixtureCollection))]
    public class DivisorServiceTests
    {
        private readonly DivisorFixture _fixture;
        private readonly DivisorService _service;

        public DivisorServiceTests(DivisorFixture fixture)
        {
            _fixture = fixture;
            _service = _fixture.GetDivisorServiceInstance();
        }

        [Trait("services", nameof(DivisorService))]
        [Fact(DisplayName = "Obter Divisores - Sucesso")]
        public async Task ObterDivisoresAsync_Sucesso()
        {
            // Arrange
            var divisorRequest = _fixture.GetDivisorRequest();
            var divisorResponse = _fixture.GetDivisorResponse();
            var divisorPrimoResponse = _fixture.GetDivisorPrimoResponse();
            var divisorPrimoRequest = _fixture.GetDivisorPrimoRequest();

            _fixture.Mocker.GetMock<IDivisorService>().Setup(x => x.ObterDivisoresAsync(It.IsAny<DivisorRequest>())).ReturnsAsync(divisorResponse);
            _fixture.Mocker.GetMock<IDivisorPrimoService>().Setup(x => x.ObterDivisoresPrimosAsync(It.IsAny<DivisorPrimoRequest>())).ReturnsAsync(divisorPrimoResponse);
            _fixture.Mocker.GetMock<IMapper>().Setup(x => x.Map<DivisorPrimoRequest>(It.IsAny<List<int>>())).Returns(divisorPrimoRequest);
            _fixture.Mocker.GetMock<IMapper>().Setup(x => x.Map<DivisorResponse>(It.IsAny<Tuple<int, List<int>, IList<int>>>())).Returns(divisorResponse);

            // Act
            var result = await _service.ObterDivisoresAsync(divisorRequest);

            // Assert
            Assert.NotNull(result);
            _fixture.Mocker.GetMock<IDivisorPrimoService>().Verify(x => x.ObterDivisoresPrimosAsync(It.IsAny<DivisorPrimoRequest>()), Times.Once);
        }

        [Trait("services", nameof(DivisorService))]
        [Fact(DisplayName = "Obter Divisores - Falha")]
        public async Task ObterDivisoresAsync_Falha()
        {
            // Arrange
            var divisorRequest = _fixture.GetDivisorRequest(false);
            var divisorResponse = _fixture.GetDivisorResponse();
            var divisorPrimoResponse = _fixture.GetDivisorPrimoResponse();
            var divisorPrimoRequest = _fixture.GetDivisorPrimoRequest();

            _fixture.Mocker.GetMock<IDivisorService>().Setup(x => x.ObterDivisoresAsync(It.IsAny<DivisorRequest>())).ReturnsAsync(divisorResponse);
            _fixture.Mocker.GetMock<IDivisorPrimoService>().Setup(x => x.ObterDivisoresPrimosAsync(It.IsAny<DivisorPrimoRequest>())).ReturnsAsync(divisorPrimoResponse);
            _fixture.Mocker.GetMock<IMapper>().Setup(x => x.Map<DivisorPrimoRequest>(It.IsAny<List<int>>())).Returns(divisorPrimoRequest);
            _fixture.Mocker.GetMock<IMapper>().Setup(x => x.Map<DivisorResponse>(It.IsAny<Tuple<int, List<int>, IList<int>>>())).Returns(divisorResponse);

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await _service.ObterDivisoresAsync(divisorRequest));

            // Assert
            Assert.Equal("O campo número deve ser maior que zero.", exception.Message);
            _fixture.Mocker.GetMock<IDivisorService>().Verify(x => x.ObterDivisoresAsync(It.IsAny<DivisorRequest>()), Times.Never);
            _fixture.Mocker.GetMock<IDivisorPrimoService>().Verify(x => x.ObterDivisoresPrimosAsync(It.IsAny<DivisorPrimoRequest>()), Times.Never);
        }
    }
}
