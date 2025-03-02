namespace ControleEstoqueAPI.Data;

using ControleEstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ControleEstoqueContext : DbContext
{
    public ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Movimentacao> Movimentacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimentacao>()
            .HasOne(m => m.Produto)
            .WithMany()
            .HasForeignKey(m => m.ProdutoId);
    }
}

