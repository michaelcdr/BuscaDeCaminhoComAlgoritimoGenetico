using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Web.Domain
{
    public class ResultadosRequest
    {
        public bool Eltismo { get; set; }
        public int TamanhoPopulacao { get; set; }
        public double TaxaCrossover { get; set; }
        public double TaxaMutacao { get; set; }
    }
}
