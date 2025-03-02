using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueAPI.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        [Column("produto_id")]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; } = null!;
        public string Tipo { get; set; } = "entrada"; // "entrada" ou "saída"
        public int Quantidade { get; set; }

        [Column("data_movimentacao")]
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
    }
}
