using B3.DesafioCalculo.Business.Business;
using B3.DesafioCalculo.Shared.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.DesafioCalculo.UnitTests.Business
{
    [TestFixture]
    public class CalculadoraInvestimentosBusinessTest
    {
        private IOptions<TaxasSettings> _mockTaxasSettings;
        private CalculadoraInvestimentosBusiness _calculadora;

        [SetUp]
        public void Setup()
        {
            _mockTaxasSettings = Options.Create(new TaxasSettings()
            {
                CDI = 1,
                TB = 1
            });

            _calculadora = new CalculadoraInvestimentosBusiness(_mockTaxasSettings);
        }

        [Test]
        public void CalcularRendimentoBrutoCDB_ShouldReturnCorrectAmount()
        {
            // Arrange
            double valorInicial = 1000;
            int prazoMeses = 1;

            // Act
            double valorBruto = _calculadora.CalcularRendimentoBrutoCDB(valorInicial, prazoMeses);

            // Assert
            Assert.That(valorBruto, Is.EqualTo(2000)); // O terceiro parâmetro é a tolerância
        }
    }
}
