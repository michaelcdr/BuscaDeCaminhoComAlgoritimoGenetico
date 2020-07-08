namespace AG.Web.Domain
{
    public class Geracao
    {
        public Geracao(PopulacaoComIndividuos populacao, bool temSolucao, int ordem)
        {
            Populacao = populacao;
            TemSolucao = temSolucao;
            Ordem = ordem;
        }

        public PopulacaoComIndividuos Populacao{ get; private set; }
        public bool TemSolucao { get; private set; }
        public int Ordem { get; private set; }
    }
}
