using AG.Web.Domain;
using AG.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
        
        [HttpPost]
        public IActionResult ObterResultados(ResultadosRequest request)
        {
            AlgoritimoGenetico.AtualizarCaracteres("01");
            AlgoritimoGenetico.AtualizarTaxaDeCrossover(request.TaxaCrossover);
            AlgoritimoGenetico.AtualizarTaxaDeMutacao(request.TaxaMutacao);

            Populacao populacao = new Populacao(request.TamanhoPopulacao);
            
            int numMaxGeracoes = 10000;
            
            bool temSolucao = false;
            
            int geracao = 0;

            //loop até o critério de parada
            List<Geracao> geracoes = new List<Geracao>();

            while (!temSolucao && geracao < numMaxGeracoes)
            {
                geracao++;

                //cria nova populacao...
                populacao = AlgoritimoGenetico.NovaGeracao(populacao, request.Eltismo);

                //verifica se tem a solucao...
                temSolucao = populacao.VerificarSeTemSolucao();

                geracoes.Add(new Geracao(populacao.ToPopulacaoComIndividuos(), temSolucao, geracao));
            }

            return Json(new {
                numMaxGeracoes,
                geracoes
            });
        }
    }
}
