using AG.Web.Domain;
using AG.Web.Helpers;
using System;
using System.Collections.Generic;

namespace AG.Web.Factories
{
    public class GeneFactory
    {
        private const string NORTE = "01";
        private const string SUL = "11";
        private const string OESTE = "10";
        private const string LESTE = "00";

        public IDirecao Gerar(string bit)
        {
            if (bit == NORTE)
                return new Norte();
            else if (bit == LESTE)
                return new Leste();
            else if (bit == OESTE)
                return new Oeste();
            else if (bit == SUL)
                return new Sul();
            else
                throw new ArgumentException();
        }

        public List<IDirecao> GerarListaDeBits(string genes)
        {
            var bits = new List<IDirecao>();

            List<string> bitsDoCaminho = GenesHelper.QuebrarStringACada2Caracteres(genes);

            var genesFactory = new GeneFactory();

            foreach (var bit in bitsDoCaminho)
                bits.Add(genesFactory.Gerar(bit));

            return bits;
        }
    }
}
