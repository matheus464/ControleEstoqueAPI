using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        [Column("categoria_id")]
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
