using AG.Web.Domain;

namespace AG.Web.Extensions
{
    public static class PopulacaoExtensions
    {
        public static PopulacaoComIndividuos ToPopulacaoComIndividuos(this Populacao populacao)
        {
            return new PopulacaoComIndividuos(populacao.ObterIndividuos());
        }
    }
}
