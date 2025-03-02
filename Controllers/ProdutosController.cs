namespace ControleEstoqueAPI.Controllers;

using ControleEstoqueAPI.Data;
using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly ControleEstoqueContext _context;

    public ProdutosController(ControleEstoqueContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
            return NotFound();
        return produto;
    }

    [HttpPost]
    [SwaggerResponse(201, "Produto criado com sucesso", typeof(Produto))]
    [SwaggerResponse(400, "Erro de validação")]
    public async Task<ActionResult<Produto>> PostProduto([FromBody] ProdutoCreateDto produtoDto)
    {
        var categoriaExistente = await _context.Categorias.FindAsync(produtoDto.CategoriaId);
        if (produtoDto.CategoriaId != null && categoriaExistente == null)
        {
            return BadRequest("A categoria informada não existe.");
        }

        var produto = new Produto
        {
            Nome = produtoDto.Nome,
            Descricao = produtoDto.Descricao,
            Quantidade = produtoDto.Quantidade,
            Preco = produtoDto.Preco,
            CategoriaId = produtoDto.CategoriaId
        };

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    [SwaggerResponse(204, "Produto atualizado com sucesso")]
    [SwaggerResponse(400, "Erro de validação")]
    [SwaggerResponse(404, "Produto não encontrado")]
    public async Task<IActionResult> PutProduto(int id, [FromBody] ProdutoUpdateDto produtoDto)
    {
        var produtoExistente = await _context.Produtos.FindAsync(id);
        if (produtoExistente == null)
        {
            return NotFound("Produto não encontrado.");
        }

        var categoriaExistente = await _context.Categorias.FindAsync(produtoDto.CategoriaId);
        if (produtoDto.CategoriaId != null && categoriaExistente == null)
        {
            return BadRequest("A categoria informada não existe.");
        }

        produtoExistente.Nome = produtoDto.Nome;
        produtoExistente.Descricao = produtoDto.Descricao;
        produtoExistente.Quantidade = produtoDto.Quantidade;
        produtoExistente.Preco = produtoDto.Preco;
        produtoExistente.CategoriaId = produtoDto.CategoriaId;

        _context.Entry(produtoExistente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
            return NotFound();

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

