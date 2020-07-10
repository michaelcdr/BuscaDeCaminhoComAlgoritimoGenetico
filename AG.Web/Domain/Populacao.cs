using System.Collections.Generic;
using System.Linq;

namespace AG.Web.Domain
{
    public class Populacao
    {
        private Individuo[] individuos;

        private int tamPopulacao;

        /// <summary>
        /// cria uma população com indivíduos sem valor, será composto posteriormente
        /// </summary>
        /// <param name="tamanhoDaPopulacao">Numero de individuos na população</param>
        public Populacao(int tamanhoDaPopulacao)
        {
            tamPopulacao = tamanhoDaPopulacao;
            
            individuos = new Individuo[tamanhoDaPopulacao];
            
            for (int i = 0; i < individuos.Length; i++)
            {
                individuos[i] = new Individuo(12);
            }
        }

        //coloca um indivíduo em uma certa posição da população
        public void setIndividuo(Individuo individuo, int posicao)
        {
            individuos[posicao] = individuo;
        }

        //coloca um indivíduo na próxima posição disponível da população
        public void setIndividuo(Individuo individuo)
        {
            for (int i = 0; i < individuos.Length; i++)
            {
                if (individuos[i] == null)
                {
                    individuos[i] = individuo;
                    return;
                }
            }
        }

        /// <summary>
        /// Verifica se algum indivíduo da população possui a solução.
        /// </summary>
        /// <param name="solucao"></param>
        /// <returns></returns>
        public bool VerificarSeTemSolucao()
        {
            return individuos.Any(individuoAtual => individuoAtual.TemSolucao);
        }

        /// <summary>
        /// Ordena a população pelo valor de aptidão de cada indivíduo, do maior valor para o menor,
        /// assim se eu quiser obter o melhor indivíduo desta população, acesso a posição 0 do array de indivíduos
        /// </summary>
        public void OrdenaPopulacao()
        {
            bool trocou = true;
            while (trocou)
            {
                trocou = false;
                for (int i = 0; i < individuos.Length - 1; i++)
                {
                    if (individuos[i].ObterAptidao() < individuos[i + 1].ObterAptidao())
                    {
                        Individuo temp = individuos[i];
                        individuos[i] = individuos[i + 1];
                        individuos[i + 1] = temp;
                        trocou = true;
                    }
                }
            }
        }

        //número de indivíduos existentes na população
        public int getNumIndividuos()
        {
            int num = 0;
            for (int i = 0; i < individuos.Length; i++)
            {
                if (individuos[i] != null)
                {
                    num++;
                }
            }
            return num;
        }

        public int getTamPopulacao()
        {
            return tamPopulacao;
        }

        public Individuo getIndividuo(int pos)
        {
            return individuos[pos];
        }

        public List<Individuo> ObterIndividuos()
        {
            return this.individuos.ToList();
        }

        public List<Individuo> TemIndividuosComSolucaoPerfeita()
        {
            return this.individuos.Where(e => e.TemSolucaoPerfeita).ToList();

        }
    }
}
