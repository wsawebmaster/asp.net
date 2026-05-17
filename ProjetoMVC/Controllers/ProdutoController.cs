using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using System.Linq;

namespace ProjetoMVC.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            List<Produto> produtos = Produto.ListaDeProdutos();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            Produto.AdicionarProduto(produto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Produto? produto = Produto.ListaDeProdutos().FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            // Buscando produtoExistente
            Produto? produtoExistente = Produto.ListaDeProdutos().FirstOrDefault(p => p.Id == produto.Id);
            if(produtoExistente != null)
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Preco = produto.Preco;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Produto? produtoExistente = Produto.ListaDeProdutos().FirstOrDefault(p => p.Id == id);
            if (produtoExistente == null)
            {
                return NotFound();
            }
            return View(produtoExistente);
        }

        [HttpPost]
        public IActionResult Excluir(Produto produto)
        {
            Produto.ExcluirProduto(produto.Id);
            return RedirectToAction("Index");
        }
    }
}
