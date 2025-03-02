namespace ControleEstoqueAPI.Dtos
{
    public class ProdutoUpdateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int? CategoriaId { get; set; }
    }
}
