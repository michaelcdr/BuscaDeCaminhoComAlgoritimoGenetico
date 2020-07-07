using AG.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AG.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ObterCaminhos()
        {
            AlgoritimoGenetico.AtualizarCaracteres("01");
            AlgoritimoGenetico.AtualizarTaxaDeCrossover(0.6);
            AlgoritimoGenetico.AtualizarTaxaDeMutacao(0.3);

            Populacao populacao = new Populacao(100);
            
            int numMaxGeracoes = 10000;
            
            bool eltismo = true;
            
            bool temSolucao = false;
            
            int geracao = 0;

            //loop até o critério de parada
            while (!temSolucao && geracao < numMaxGeracoes)
            {
                geracao++;

                //cria nova populacao
                populacao = AlgoritimoGenetico.NovaGeracao(populacao, eltismo);

                //verifica se tem a solucao
                temSolucao = populacao.VerificarSeTemSolucao();
            }

            return Json(new {
                numMaxGeracoes,
                geracao
            });
        }
    }
}
