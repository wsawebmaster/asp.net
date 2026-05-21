using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto04.PrimeiraAPI.Model;

namespace Projeto04.PrimeiraAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>();

        // Método Post: api/produto
        [HttpPost]

        public IActionResult Post([FromBody] Produto novoProduto)
        {
            if (novoProduto == null)
            {
                return BadRequest("Produto Inválido!");
            }

            novoProduto.Id = produtos.Count + 1;

            produtos.Add(novoProduto);

            return Ok(novoProduto);
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]

        public IActionResult BurcarPorId(int id)
        {
            Produto? produto = produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            return Ok(produto);
        }

        // PUT - Atualizar um produto já existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            Produto? produtoExistente = produtos.FirstOrDefault(produto => produto.Id == id);

            if (produtoExistente == null)
            {
                return NotFound("Produto não encontrado");
            }

            // Atualizando produto existente
            produtoExistente.Nome = produto.Nome;
            produtoExistente.Preco = produto.Preco;

            return Ok(produtoExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Produto? produtoExistente = produtos.FirstOrDefault(produto => produto.Id == id);

            if (produtoExistente == null)
            {
                return NotFound("Produto não encontrado");
            }

            // Remover produto
            produtos.Remove(produtoExistente);

            // 204 - Sucesso sem retorno de dados
            return NoContent();
        }
    }
}
