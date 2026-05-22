using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projeto05.EntityFramework.Model;

// ORM
// Object-Relational Mapper

// Code First - O banco de dados não precisa ser criado antes.

// Gerenciar a conexão e manipulação das entidades de dados

public class ApplicationDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MinhaLoja;Trusted_Connection=true;TrustServerCertificate=true;");
    }
}

class Program
{
    static void Main()
    {
        using (var context = new ApplicationDbContext())
        {
            // Create
            var novoProduto = new Produto { Nome = "Notebook", Preco = 3500 };
            context.Produtos.Add(novoProduto);
            context.SaveChanges();
        }
    }
}