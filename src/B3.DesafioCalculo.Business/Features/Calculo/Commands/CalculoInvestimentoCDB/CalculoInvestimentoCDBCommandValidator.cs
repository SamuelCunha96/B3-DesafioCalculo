using FluentValidation;

namespace B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB
{
    public class CalculoInvestimentoCdbCommandValidator : AbstractValidator<CalculoInvestimentoCdbCommand>
    {
        public CalculoInvestimentoCdbCommandValidator()
        {
            RuleFor(x => x.ValorInicial)
                .GreaterThan(0)
                .WithMessage("O valor inicial de investimento deve ser maior que zero");

            RuleFor(x => x.PrazoMeses)
                .GreaterThan(1)
                .WithMessage("O prazo em meses deve ser maior que 1");
        }
    }
}
