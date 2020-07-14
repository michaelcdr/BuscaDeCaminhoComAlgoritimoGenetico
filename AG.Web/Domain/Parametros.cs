using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Web.Domain
{
    public static class Parametros
    {
        private static int _pontosPorCelulaOcupada = 1;
        private static int _pontosPorAtravessiaDeParedes = 50;
        private static int _pontosPorSairDoCenario = 100;

        //private const string NORTE = "01";
        //private const string LESTE = "00";
        //private const string OESTE = "10";
        //private const string SUL = "11";

        public static int PontosPorCelulaOcupada 
        { 
            get { return _pontosPorCelulaOcupada; }
        }

        public static int PontosPorAtravessiaDeParedes
        {
            get { return _pontosPorAtravessiaDeParedes; }
        }

        public static int PontosPorSairDoCenario
        {
            get { return _pontosPorSairDoCenario; }
        }
    }
}
