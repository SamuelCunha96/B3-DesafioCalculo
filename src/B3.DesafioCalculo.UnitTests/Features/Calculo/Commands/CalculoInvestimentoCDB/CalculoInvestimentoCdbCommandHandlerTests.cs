using B3.DesafioCalculo.Business.Contracts;
using B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB;
using Moq;

namespace B3.DesafioCalculo.UnitTests.Features.Calculo.Commands.CalculoInvestimentoCDB
{
    public class CalculoInvestimentoCdbCommandHandlerTests
    {
        private Mock<ICalculadoraInvestimentosBusiness> _mockCalculadoraInvestimentosBusiness;
        private CalculoInvestimentoCdbCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockCalculadoraInvestimentosBusiness = new Mock<ICalculadoraInvestimentosBusiness>();
            _handler = new CalculoInvestimentoCdbCommandHandler(_mockCalculadoraInvestimentosBusiness.Object);
        }

        [Test]
        public async Task Handle_TaxaPrazoAte6Meses_ShouldReturnCorrectResult()
        {
            // Arrange
            var request = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 1000,
                PrazoMeses = 6
            };

            _mockCalculadoraInvestimentosBusiness
                .Setup(b => b.CalcularRendimentoBrutoCDB(It.IsAny<double>(), It.IsAny<int>()))
                .Returns(1200);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ResultadoInvestimentoValorLiquido, Is.EqualTo(1155));
        }

        [Test]
        public async Task Handle_TaxaPrazoDe7Ate12Meses_ShouldReturnCorrectResult()
        {
            // Arrange
            var request = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 1000,
                PrazoMeses = 12
            };

            _mockCalculadoraInvestimentosBusiness
                .Setup(b => b.CalcularRendimentoBrutoCDB(It.IsAny<double>(), It.IsAny<int>()))
                .Returns(1200);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ResultadoInvestimentoValorLiquido, Is.EqualTo(1160));
        }

        [Test]
        public async Task Handle_TaxaPrazoDe13Ate24Meses_ShouldReturnCorrectResult()
        {
            // Arrange
            var request = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 1000,
                PrazoMeses = 24
            };

            _mockCalculadoraInvestimentosBusiness
                .Setup(b => b.CalcularRendimentoBrutoCDB(It.IsAny<double>(), It.IsAny<int>()))
                .Returns(1200);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ResultadoInvestimentoValorLiquido, Is.EqualTo(1165));
        }

        [Test]
        public async Task Handle_TaxaPrazoMaiorQue24Meses_ShouldReturnCorrectResult()
        {
            // Arrange
            var request = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 1000,
                PrazoMeses = 25
            };

            _mockCalculadoraInvestimentosBusiness
                .Setup(b => b.CalcularRendimentoBrutoCDB(It.IsAny<double>(), It.IsAny<int>()))
                .Returns(1200);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ResultadoInvestimentoValorLiquido, Is.EqualTo(1170));
        }
    }
}
