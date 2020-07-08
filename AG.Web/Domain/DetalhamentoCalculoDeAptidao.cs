using System.Collections.Generic;

namespace AG.Web.Domain
{
    public class DetalhamentoCalculoDeAptidao
    {
        public DetalhamentoCalculoDeAptidao(int aptidao, bool temSolucao, List<string> bits, List<Coordenadas> coordenadas)
        {
            Aptidao = aptidao;
            TemSolucao = temSolucao;
            Bits = bits;
            Coordenadas = coordenadas;
        }

        public int Aptidao { get; private set; }
        public bool TemSolucao { get; private set; }
        public List<string> Bits { get; private set; }
        public List<Coordenadas> Coordenadas { get; private set; }
    }
}
