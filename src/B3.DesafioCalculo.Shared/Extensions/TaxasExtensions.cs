namespace B3.DesafioCalculo.Shared.Extensions
{
    public static class TaxasExtensions
    {
        public static double ObterTaxaDeImpostos(this int prazoMeses) 
        {
            var taxaDeImpostos = 0.0d;

            if (prazoMeses <= 6)
                taxaDeImpostos = 0.225;
            else if (prazoMeses <= 12)
                taxaDeImpostos = 0.20;
            else if (prazoMeses <= 24)
                taxaDeImpostos = 0.175;
            else
                taxaDeImpostos = 0.15;

            return taxaDeImpostos;
        }
    }
}
