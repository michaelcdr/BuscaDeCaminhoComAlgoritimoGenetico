using AG.Web.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AG.Web.Domain
{
    public class Individuo
    {
        private List<IDirecao> _genes = new List<IDirecao>();

        public int Aptidao  { get; private set; }
        public bool TemSolucao { get; private set; }
        public bool TemSolucaoPerfeita { get;  set; }

        public List<IDirecao> Bits { get; private set; }
        public List<Coordenadas> Coordenadas { get; private set; }
        public int Colisoes { get; private set; }

        /// <summary>
        /// Gera um indivíduo aleatório com o número de genes parametrizado.
        /// </summary>
        /// <param name="numGenes">Numero de genes</param>
        public Individuo(int numGenes)
        {
            Random r = new Random();

            string caracteres = AlgoritimoGenetico.ObterCaracteres();
            
            string genes = string.Empty;

            for (int i = 0; i < numGenes; i++)
                genes += caracteres.ElementAt(r.Next(caracteres.Length));

            GeneFactory geneFactory = new GeneFactory();

            _genes = geneFactory.GerarListaDeBits(genes);

            GerarAptidao();
        }

        /// <summary>
        /// Cria um indivíduo com os genes definidos
        /// </summary>
        /// <param name="genes"></param>
        public Individuo(string genes)
        {
            GeneFactory geneFactory = new GeneFactory();

            this._genes = geneFactory.GerarListaDeBits(genes);

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
                this._genes = geneFactory.GerarListaDeBits(geneNovo);
            }
            GerarAptidao();
        }

        /// <summary>
        /// Gera o valor de aptidão, será pelo numero de vezes que saimos do cenario ou colidimos;
        /// </summary>
        private void GerarAptidao()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular(_genes);

            Aptidao = detalhamentoCalculoDeAptidao.Aptidao;

            TemSolucao = detalhamentoCalculoDeAptidao.TemSolucao;

            Bits = detalhamentoCalculoDeAptidao.Bits;

            Coordenadas = detalhamentoCalculoDeAptidao.Coordenadas;

            Colisoes = detalhamentoCalculoDeAptidao.Colisoes;

            TemSolucaoPerfeita = detalhamentoCalculoDeAptidao.TemSolucaoPerfeita;
        }

        public int ObterAptidao()
            => Aptidao;

        public List<IDirecao> ObterGenes()
            => _genes;
    }
}
