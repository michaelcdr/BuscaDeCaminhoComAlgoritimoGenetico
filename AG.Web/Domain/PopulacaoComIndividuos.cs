using System.Collections.Generic;

namespace AG.Web.Domain
{
    public class PopulacaoComIndividuos
    {
        public List<Individuo> Individuos { get; private set; }

        public PopulacaoComIndividuos(List<Individuo> individuos)
        {
            this.Individuos = individuos;
        }
    }
}
