namespace ProjetoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        // Método que retorna uma lista de produtos
        public static List<Produto> ListarProdutos()
        {
            return new List<Produto>
            {
                new Produto { Id = 1, Nome = "Notebook", Preco = 3500.00 },
                new Produto { Id = 2, Nome = "Smartphone", Preco = 100.00 }
            };
        }
    }
}
