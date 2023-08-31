using B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB;
using FluentValidation.TestHelper;

namespace B3.DesafioCalculo.UnitTests.Features.Calculo.Commands.CalculoInvestimentoCDB
{
    public class CalculoInvestimentoCdbCommandValidatorTests
    {
        private CalculoInvestimentoCdbCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CalculoInvestimentoCdbCommandValidator();
        }

        [Test]
        public void Validate_InvalidValorInicial_ShouldHaveValidationError()
        {
            var model = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 0,
                PrazoMeses = 12
            };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.ValorInicial);
        }

        [Test]
        public void Validate_InvalidPrazoMesMenorQue1_ShouldHaveValidationError()
        {
            var model = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 1000,
                PrazoMeses = -1
            };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PrazoMeses);
        }

        [Test]
        public void Validate_InvalidPrazo1Mes_ShouldHaveValidationError()
        {
            var model = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 1000,
                PrazoMeses = 1
            };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PrazoMeses);
        }

        [Test]
        public void Validate_ValidModel_ShouldNotHaveValidationError()
        {
            var model = new CalculoInvestimentoCdbCommand
            {
                ValorInicial = 1000,
                PrazoMeses = 12
            };

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
