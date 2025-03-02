namespace ControleEstoqueAPI.Dtos
{
    public class ProdutoCreateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int? CategoriaId { get; set; }
    }

}
