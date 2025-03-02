namespace ControleEstoqueAPI.Controllers;

using ControleEstoqueAPI.Data;
using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class MovimentacoesController : ControllerBase
{
    private readonly ControleEstoqueContext _context;

    public MovimentacoesController(ControleEstoqueContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movimentacao>>> GetMovimentacoes()
    {
        return await _context.Movimentacoes.Include(m => m.Produto).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Movimentacao>> PostMovimentacao([FromBody] MovimentacaoCreateDto movimentacaoDto)
    {
        var produto = await _context.Produtos.FindAsync(movimentacaoDto.ProdutoId);
        if (produto == null)
            return BadRequest("Produto não encontrado.");

        if (movimentacaoDto.Tipo == "saida" && produto.Quantidade < movimentacaoDto.Quantidade)
            return BadRequest("Estoque insuficiente.");

        if (movimentacaoDto.Tipo == "entrada")
            produto.Quantidade += movimentacaoDto.Quantidade;
        else
            produto.Quantidade -= movimentacaoDto.Quantidade;

        var movimentacao = new Movimentacao 
        {
            ProdutoId = movimentacaoDto.ProdutoId,
            Tipo = movimentacaoDto.Tipo,
            Quantidade = movimentacaoDto.Quantidade
        };

        _context.Movimentacoes.Add(movimentacao);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMovimentacoes", new { id = movimentacao.Id }, movimentacao);
    }
}

