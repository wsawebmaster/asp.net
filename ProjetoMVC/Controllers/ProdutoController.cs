using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    // É responsável por lidar com as requisições relacionadas aos produtos
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            // Obtém a lista de produtos do Model e passa para a Vie
            List<Produto> produtos = Produto.ListaDeProdutos();

            // Enviando a lista de produtos para a View
            return View(produtos);
        }
    }
}
