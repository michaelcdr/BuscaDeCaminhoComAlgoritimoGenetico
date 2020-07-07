﻿using System;

namespace ExemploAlgoritimoGenetico
{
    public class Populacao
    {
        private Individuo[] individuos;
        private int tamPopulacao;

        //cria uma população com indivíduos aleatória
        public Populacao(int numGenes, int tamPop)
        {
            tamPopulacao = tamPop;
            individuos = new Individuo[tamPop];
            for (int i = 0; i < individuos.Length; i++)
            {
                individuos[i] = new Individuo(numGenes);
            }
        }

        //cria uma população com indivíduos sem valor, será composto posteriormente
        public Populacao(int tamPop)
        {
            tamPopulacao = tamPop;
            individuos = new Individuo[tamPop];
            for (int i = 0; i < individuos.Length; i++)
            {
                individuos[i] = null;
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

        //verifica se algum indivíduo da população possui a solução
        public bool temSolucao(String solucao)
        {
            Individuo i = null;
            for (int j = 0; j < individuos.Length; j++)
            {
                if (individuos[j].getGenes().Equals(solucao))
                {
                    i = individuos[j];
                    break;
                }
            }
            if (i == null)
            {
                return false;
            }
            return true;
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
                    if (individuos[i].getAptidao() < individuos[i + 1].getAptidao())
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
    }
}
