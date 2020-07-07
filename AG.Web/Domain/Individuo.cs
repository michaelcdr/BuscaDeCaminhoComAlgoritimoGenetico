using System;
using System.Linq;

namespace AG.Web.Domain
{
    public class Individuo
    {
        private string _genes = string.Empty;

        private int _aptidao = 0;
        
        public bool _temSolucao { get; private set; }

        /// <summary>
        /// Gera um indivíduo aleatório com o número de genes parametrizado.
        /// </summary>
        /// <param name="numGenes">Numero de genes</param>
        public Individuo(int numGenes)
        {
            _genes = string.Empty;

            Random r = new Random();

            string caracteres = AlgoritimoGenetico.ObterCaracteres();

            for (int i = 0; i < numGenes; i++)
            {
                _genes += caracteres.ElementAt(r.Next(caracteres.Length));
            }

            GerarAptidao();
        }

        /// <summary>
        /// Cria um indivíduo com os genes definidos
        /// </summary>
        /// <param name="genes"></param>
        public Individuo(string genes)
        {
            this._genes = genes;

            Random r = new Random();

            //se for mutar, cria um gene aleatório
            if (r.NextDouble() <= AlgoritimoGenetico.ObterTaxaDeMutacao())
            {
                string caracteres = AlgoritimoGenetico.ObterCaracteres();

                string geneNovo = string.Empty;

                int posAleatoria = r.Next(genes.Length);

                for (int i = 0; i < genes.Length; i++)
                {
                    if (i == posAleatoria)
                    {
                        geneNovo += caracteres.ElementAt(r.Next(caracteres.Length));
                    }
                    else
                    {
                        geneNovo += genes.ElementAt(i);
                    }

                }
                this._genes = geneNovo;
            }
            GerarAptidao();
        }

        /// <summary>
        /// Gera o valor de aptidão, será pelo numero de vezes que saimos do cenario ou colidimos;
        /// </summary>
        private void GerarAptidao()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular(_genes);

            _aptidao = detalhamentoCalculoDeAptidao.Aptidao;

            _temSolucao = detalhamentoCalculoDeAptidao.TemSolucao;
        }

        public int ObterAptidao()
            => _aptidao;

        public string ObterGenes()
            => _genes;
    }
}
