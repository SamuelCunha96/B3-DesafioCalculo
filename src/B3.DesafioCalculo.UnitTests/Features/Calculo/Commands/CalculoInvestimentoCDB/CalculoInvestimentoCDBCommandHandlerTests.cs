using B3.DesafioCalculo.Business.Contracts;
using B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB;
using Moq;

namespace B3.DesafioCalculo.UnitTests.Features.Calculo.Commands.CalculoInvestimentoCDB
{
    public class CalculoInvestimentoCDBCommandHandlerTests
    {
        private Mock<ICalculadoraInvestimentosBusiness> _mockCalculadoraInvestimentosBusiness;
        private CalculoInvestimentoCDBCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockCalculadoraInvestimentosBusiness = new Mock<ICalculadoraInvestimentosBusiness>();
            _handler = new CalculoInvestimentoCDBCommandHandler(_mockCalculadoraInvestimentosBusiness.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ShouldReturnCorrectResult()
        {
            // Arrange
            var request = new CalculoInvestimentoCDBCommand
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
            Assert.IsNotNull(result);
            Assert.That(result.ResultadoInvestimentoValorBruto, Is.EqualTo(1200));
        }
    }
}
