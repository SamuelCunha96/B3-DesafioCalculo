using B3.DesafioCalculo.Business.Contracts;
using B3.DesafioCalculo.Shared.Settings;
using Microsoft.Extensions.Options;

namespace B3.DesafioCalculo.Business.Business
{
    public class CalculadoraInvestimentosBusiness : ICalculadoraInvestimentosBusiness
    {
        private readonly TaxasSettings _taxasSettings;

        public CalculadoraInvestimentosBusiness(IOptions<TaxasSettings> taxasSettings)
        {
            _taxasSettings = taxasSettings.Value;
        }

        public double CalcularRendimentoBrutoCDB(double valorInicial, int prazoMeses)
        {
            double valorBruto = valorInicial;

            for (int i = 0; i < prazoMeses; i++)
            {
                valorBruto *= (1 + (_taxasSettings.CDI * _taxasSettings.TB));
            }

            return valorBruto;
        }
    }
}
