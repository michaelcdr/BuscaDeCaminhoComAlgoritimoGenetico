using System;
using AG.Web.Extensions;

namespace AG.Web.Domain
{
    public class AlgoritimoGenetico
    {
        private static string _caracteres;
        private static double _taxaDeCrossover;
        private static double _taxaDeMutacao;

        public static void AtualizarCaracteres(string caracteres)
        {
            _caracteres = caracteres;
        }

        public static void AtualizarTaxaDeCrossover(double taxaDeCrossover)
        {
            _taxaDeCrossover = taxaDeCrossover;
        }

        public static void AtualizarTaxaDeMutacao(double taxaDeMutacao)
        {
            _taxaDeMutacao = taxaDeMutacao;
        }

        public static string ObterCaracteres()
            => _caracteres;
        public static double ObterTaxaDeMutacao()
            => _taxaDeMutacao;

        public static Populacao Gerar(Populacao populacao, bool elitismo)
        {
            Random r = new Random();

            //nova população do mesmo tamanho da antiga
            Populacao novaPopulacao = new Populacao(populacao.getTamPopulacao());

            //se tiver elitismo, mantém o melhor indivíduo da geração atual
            if (elitismo)
            {
                novaPopulacao.setIndividuo(populacao.getIndividuo(0));
            }

            //insere novos indivíduos na nova população, até atingir o tamanho máximo
            while (novaPopulacao.getNumIndividuos() < novaPopulacao.getTamPopulacao())
            {
                //seleciona os 2 pais por torneio
                Individuo[] pais = SelecaoTorneio(populacao);

                Individuo[] filhos = new Individuo[2];

                //verifica a taxa de crossover, se sim realiza o crossover, se não, mantém os pais selecionados para a próxima geração
                if (r.NextDouble() <= _taxaDeCrossover)
                {
                    filhos = Crossover(pais[1], pais[0]);
                }
                else
                {
                    filhos[0] = new Individuo(pais[0].ObterGenes().Count);
                    filhos[1] = new Individuo(pais[1].ObterGenes().Count);
                }

                //adiciona os filhos na nova geração
                novaPopulacao.setIndividuo(filhos[0]);
                novaPopulacao.setIndividuo(filhos[1]);
            }

            //ordena a nova população
            novaPopulacao.OrdenaPopulacao();
            return novaPopulacao;
        }

        public static Individuo[] Crossover(Individuo individuo1, Individuo individuo2)
        {
            Random r = new Random();

            //sorteia o ponto de corte
            int pontoCorte1 = r.Next((individuo1.ObterGenes().Count / 2) - 2) + 1;
            int pontoCorte2 = r.Next((individuo1.ObterGenes().Count / 2) - 2) + individuo1.ObterGenes().Count / 2;

            Individuo[] filhos = new Individuo[2];

            //pega os genes dos pais
            String genePai1 = string.Join("", individuo1.ObterGenes());
            String genePai2 = string.Join("", individuo2.ObterGenes());

            String geneFilho1;
            String geneFilho2;

            //realiza o corte, 
            geneFilho1 = genePai1.SubstringDoJava(0, pontoCorte1);
            geneFilho1 += genePai2.SubstringDoJava(pontoCorte1, pontoCorte2);
            geneFilho1 += genePai1.SubstringDoJava(pontoCorte2, genePai1.Length);

            geneFilho2 = genePai2.SubstringDoJava(0, pontoCorte1);
            geneFilho2 += genePai1.SubstringDoJava(pontoCorte1, pontoCorte2);
            geneFilho2 += genePai2.SubstringDoJava(pontoCorte2, genePai2.Length);

            //cria o novo indivíduo com os genes dos pais
            filhos[0] = new Individuo(geneFilho1);
            filhos[1] = new Individuo(geneFilho2);

            return filhos;
        }

        public static Individuo[] SelecaoTorneio(Populacao populacao)
        {
            Random r = new Random();
            Populacao populacaoIntermediaria = new Populacao(3);

            //seleciona 3 indivíduos aleatóriamente na população
            populacaoIntermediaria.setIndividuo(populacao.getIndividuo(r.Next(populacao.getTamPopulacao())));
            populacaoIntermediaria.setIndividuo(populacao.getIndividuo(r.Next(populacao.getTamPopulacao())));
            populacaoIntermediaria.setIndividuo(populacao.getIndividuo(r.Next(populacao.getTamPopulacao())));

            //ordena a população
            populacaoIntermediaria.OrdenaPopulacao();

            Individuo[] pais = new Individuo[2];

            //seleciona os 2 melhores deste população
            pais[0] = populacaoIntermediaria.getIndividuo(0);
            pais[1] = populacaoIntermediaria.getIndividuo(1);

            return pais;
        }
    }
}