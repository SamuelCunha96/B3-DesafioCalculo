using FluentValidation;

namespace B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB
{
    public class CalculoInvestimentoCDBCommandValidator : AbstractValidator<CalculoInvestimentoCDBCommand>
    {
        public CalculoInvestimentoCDBCommandValidator()
        {
            RuleFor(x => x.ValorInicial)
                .GreaterThan(0)
                .WithMessage("O valor inicial de investimento deve ser maior que zero");

            RuleFor(x => x.PrazoMeses)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O prazo deve ser maior ou igual a 1 mês");
        }
    }
}
