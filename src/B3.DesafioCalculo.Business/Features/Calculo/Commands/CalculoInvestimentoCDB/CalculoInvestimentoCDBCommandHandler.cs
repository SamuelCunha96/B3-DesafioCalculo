using B3.DesafioCalculo.Business.Contracts;
using MediatR;
using B3.DesafioCalculo.Shared.Extensions;

namespace B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB
{
    public class CalculoInvestimentoCdbCommandHandler : IRequestHandler<CalculoInvestimentoCdbCommand, CalculoInvestimentoCdbCommandVm>
    {
        private readonly ICalculadoraInvestimentosBusiness _calculadoraInvestimentosBusiness;

        public CalculoInvestimentoCdbCommandHandler(ICalculadoraInvestimentosBusiness calculadoraInvestimentosBusiness)
        {
            _calculadoraInvestimentosBusiness = calculadoraInvestimentosBusiness;
        }

        public Task<CalculoInvestimentoCdbCommandVm> Handle(CalculoInvestimentoCdbCommand request, CancellationToken cancellationToken)
        {
            double resultadoInvestimentoBruto = _calculadoraInvestimentosBusiness.CalcularRendimentoBrutoCDB(request.ValorInicial, request.PrazoMeses);
            
            double lucroBruto = CalcularLucroBruto(request.ValorInicial, resultadoInvestimentoBruto);
            
            var resultadoInvestimentoLiquido = CalcularResultadoInvestimentoLiquido(request.ValorInicial, lucroBruto, request.PrazoMeses);

            return Task.FromResult(new CalculoInvestimentoCdbCommandVm 
            {
                ResultadoInvestimentoValorBruto = resultadoInvestimentoBruto,
                ResultadoInvestimentoValorLiquido = resultadoInvestimentoLiquido,
            });
        }

        private static double CalcularResultadoInvestimentoLiquido(double valorInicial, double lucroBruto, int prazoMeses)
            => valorInicial + (lucroBruto * (1 - prazoMeses.ObterTaxaDeImpostos()));

        private static double CalcularLucroBruto(double valorInicial, double resultadoInvestimentoBruto)
            => resultadoInvestimentoBruto - valorInicial;
    }
}
