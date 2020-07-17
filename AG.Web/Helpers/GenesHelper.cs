using AG.Web.Domain;
using AG.Web.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Web.Helpers
{
    public class GenesHelper
    {
        

        public static List<string> QuebrarStringACada2Caracteres(string genes)
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
    }
}

