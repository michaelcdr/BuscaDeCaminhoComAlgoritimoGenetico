using System.Collections.Generic;

namespace AG.Web.Domain
{
    public static class CalculadorDeAptidao
    {

        private static int _pontosPorCelulaOcupada = Parametros.PontosPorCelulaOcupada;
        private static int _pontosPorAtravessiaDeParedes = Parametros.PontosPorAtravessiaDeParedes;
        private static int _pontosPorSairDoCenario = Parametros.PontosPorSairDoCenario;

        private const string NORTE = "01";
        private const string LESTE = "00";
        private const string OESTE = "10";
        private const string SUL   = "11";

        private static List<string> QuebrarStringACada2Caracteres(string genes)
        {
            List<string> bitsDoCaminho = new List<string>();

            string bit = string.Empty;
            
            int contador = 0;
            
            for (int i = 0; i < 12; i++)
            {
                bit += genes[i];
                
                contador++;

                if (contador == 2)
                {
                    bitsDoCaminho.Add(bit);
                    bit = string.Empty;
                    contador = 0;
                }
            }
            return bitsDoCaminho;
        }

        public static DetalhamentoCalculoDeAptidao Calcular(string genes)
        {
            List<string> bitsDoCaminho = QuebrarStringACada2Caracteres(genes);

            int aptidao = 0;
            int x = 0;
            int y = 0;
            int posicaoX_Anterior = 0;
            int posicaoY_Anterior = 0;
            bool saiuCenario = false;
            bool temSolucao = false;
            bool temSolucaoPerfeita = false;
            int colisoes = 0;
            var coordenadasLista = new List<Coordenadas>();

            foreach (var bitDoCaminho in bitsDoCaminho)
            {
                if (bitDoCaminho == LESTE)
                    x++;
                else if (bitDoCaminho == NORTE)
                    y++;
                else if (bitDoCaminho == OESTE)
                    x--;
                else if (bitDoCaminho == SUL)
                    y--;

                if (SaiuDoCenario(x, y))
                    saiuCenario = true;

                if (VerificarAtravessiaDeParedes(x, y, posicaoX_Anterior, posicaoY_Anterior))
                {
                    aptidao += _pontosPorAtravessiaDeParedes;
                    colisoes++; 
                }

                if (VerificarSeChegouNoFim(x, y))
                    temSolucao = true;

                posicaoX_Anterior = x;
                posicaoY_Anterior = y;

                aptidao += _pontosPorCelulaOcupada;

                coordenadasLista.Add(new Coordenadas(x, y));
            }

            //saiu do cenario...
            if (saiuCenario)
                aptidao += _pontosPorSairDoCenario;

            if ((_pontosPorCelulaOcupada * 6) == aptidao && !saiuCenario && VerificarSeChegouNoFim(x, y))
                temSolucaoPerfeita = true;
            
            return new DetalhamentoCalculoDeAptidao(
                aptidao, 
                temSolucao,
                bitsDoCaminho,
                coordenadasLista,
                colisoes,
                temSolucaoPerfeita
            );
        }

        private static bool VerificarSeChegouNoFim(int x, int y)
        {
            if (x == 3 && y == 3)
                return true;

            return false;
        }

        /// <summary>
        /// Retorna true quando ocorrer uma travessia entre uma parede.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="posicaoX_Anterior"></param>
        /// <param name="posicaoY_Anterior"></param>
        /// <returns></returns>
        private static bool VerificarAtravessiaDeParedes(int x, int y, int posicaoX_Anterior, int posicaoY_Anterior)
        {
            //parede 1
            if (posicaoX_Anterior == 1 && posicaoY_Anterior == 0 && x == 1 && y == 1)
                return true;

            if (posicaoX_Anterior == 1 && posicaoY_Anterior == 1 && x == 1 && y == 0)
                return true;

            if (posicaoX_Anterior == 1 && posicaoY_Anterior == 1 && x == 2 && y == 1)
                return true;

            if (posicaoX_Anterior == 2 && posicaoY_Anterior == 1 && x == 1 && y == 1)
                return true;

            //parede 2
            if (posicaoX_Anterior == 1 && posicaoY_Anterior == 2 && x == 2 && y == 2)
                return true;

            if (posicaoX_Anterior == 2 && posicaoY_Anterior == 2 && x == 2 && y == 1)
                return true;

            if (posicaoX_Anterior == 1 && posicaoY_Anterior == 2 && x == 1 && y == 3)
                return true;

            if (posicaoX_Anterior == 3 && posicaoY_Anterior == 3 && x == 1 && y == 2)
                return true;

            //parede 3
            if (posicaoX_Anterior == 2 && posicaoY_Anterior == 1 && x == 3 && y == 1)
                return true;

            if (posicaoX_Anterior == 3 && posicaoY_Anterior == 1 && x == 2 && y == 1)
                return true;

            if (posicaoX_Anterior == 3 && posicaoY_Anterior == 1 && x == 3 && y == 2)
                return true;

            if (posicaoX_Anterior == 3 && posicaoY_Anterior == 2 && x == 3 && y == 1)
                return true;

            return false;
        }

        private static bool SaiuDoCenario(int x, int y)
            => (x > 3 || x < 0 || y < 0 || y > 3);
    }
}
