using B3.DesafioCalculo.Business.Contracts;
using MediatR;
using B3.DesafioCalculo.Shared.Extensions;

namespace B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB
{
    public class CalculoInvestimentoCDBCommandHandler : IRequestHandler<CalculoInvestimentoCDBCommand, CalculoInvestimentoCDBCommandVM>
    {
        private readonly ICalculadoraInvestimentosBusiness _calculadoraInvestimentosBusiness;

        public CalculoInvestimentoCDBCommandHandler(ICalculadoraInvestimentosBusiness calculadoraInvestimentosBusiness)
        {
            _calculadoraInvestimentosBusiness = calculadoraInvestimentosBusiness;
        }

        public Task<CalculoInvestimentoCDBCommandVM> Handle(CalculoInvestimentoCDBCommand request, CancellationToken cancellationToken)
        {
            double resultadoInvestimentoBruto = _calculadoraInvestimentosBusiness.CalcularRendimentoBrutoCDB(request.ValorInicial, request.PrazoMeses);
            
            double lucroBruto = CalcularLucroBruto(request.ValorInicial, resultadoInvestimentoBruto);
            
            var resultadoInvestimentoLiquido = CalcularResultadoInvestimentoLiquido(request.ValorInicial, lucroBruto, request.PrazoMeses);

            return Task.FromResult(new CalculoInvestimentoCDBCommandVM 
            {
                ResultadoInvestimentoValorBruto = resultadoInvestimentoBruto,
                ResultadoInvestimentoValorLiquido = resultadoInvestimentoLiquido,
            });
        }

        private double CalcularResultadoInvestimentoLiquido(double valorInicial, double lucroBruto, int prazoMeses)
            => valorInicial + (lucroBruto * (1 - prazoMeses.ObterTaxaDeImpostos()));

        private double CalcularLucroBruto(double valorInicial, double resultadoInvestimentoBruto)
            => resultadoInvestimentoBruto - valorInicial;
    }
}
