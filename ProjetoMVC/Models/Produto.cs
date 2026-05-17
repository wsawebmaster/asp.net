namespace ProjetoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        // Lista estática para persistência (simulando banco de dados)
        private static List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Notebook", Preco = 3500.00 },
            new Produto { Id = 2, Nome = "Smartphone", Preco = 100.00 }
        };

        public static List<Produto> ListarProdutos()
        {
            return _produtos;
        }

        public static List<Produto> ListaDeProdutos()
        {
            return _produtos;
        }

        public static void AdicionarProduto(Produto produto)
        {
            produto.Id = _produtos.Max(p => p.Id) + 1;
            _produtos.Add(produto);
        }

        public static void ExcluirProduto(int id)
        {
            Produto? produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
    }
}
