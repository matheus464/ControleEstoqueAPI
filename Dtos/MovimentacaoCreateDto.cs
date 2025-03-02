namespace ControleEstoqueAPI.Dtos
{
    public class MovimentacaoCreateDto
    {
        public int ProdutoId { get; set; }
        public String Tipo { get; set; } = "entrada";
        public int Quantidade { get; set; }
    }
}
