using MediatR;

namespace B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB
{
    public class CalculoInvestimentoCdbCommand : IRequest<CalculoInvestimentoCdbCommandVm>
    {
        public double ValorInicial { get; set; }
        public int PrazoMeses { get; set; }
    }
}
