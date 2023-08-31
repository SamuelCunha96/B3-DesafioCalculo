using B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB;
using FluentValidation.TestHelper;

namespace B3.DesafioCalculo.UnitTests.Features.Calculo.Commands.CalculoInvestimentoCDB
{
    public class CalculoInvestimentoCDBCommandValidatorTests
    {
        private CalculoInvestimentoCDBCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CalculoInvestimentoCDBCommandValidator();
        }

        [Test]
        public void Validate_InvalidValorInicial_ShouldHaveValidationError()
        {
            var model = new CalculoInvestimentoCDBCommand
            {
                ValorInicial = 0,
                PrazoMeses = 12
            };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.ValorInicial);
        }

        [Test]
        public void Validate_InvalidPrazoMeses_ShouldHaveValidationError()
        {
            var model = new CalculoInvestimentoCDBCommand
            {
                ValorInicial = 1000,
                PrazoMeses = -1
            };

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PrazoMeses);
        }

        [Test]
        public void Validate_ValidModel_ShouldNotHaveValidationError()
        {
            var model = new CalculoInvestimentoCDBCommand
            {
                ValorInicial = 1000,
                PrazoMeses = 12
            };

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
