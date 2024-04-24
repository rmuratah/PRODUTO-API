using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produtos.Models;
using Produtos.ViewModels;

namespace Produtos.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet("Produtos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var Produtos = await context
                .Produtos
                .AsNoTracking()
                .ToListAsync();

            return Ok(Produtos);
        }

        [HttpGet("Produtos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int Id
        )
        {
            var Produto = await context
                .Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);

            return Produto == null ? NotFound() : Ok(Produto);
        }

        [HttpPost("Produtos")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateProdutoViewModel model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produto = new Produto
            {
                Nome = model.Nome,
                Preco = model.Preco ?? 00.0,
                Descricao = model.Descricao,
            };

            try
            {
                await context.Produtos.AddAsync(produto);
                await context.SaveChangesAsync();
                return Created($"v1/todos/{produto.Id}", produto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Produtos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id,
            [FromBody] CreateProdutoViewModel model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Produto = await context
                .Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (Produto == null)
                return NotFound();

            try
            {
                Produto.Nome = model.Nome;
                Produto.Preco = model.Preco ?? 00.0;
                Produto.Descricao = model.Descricao;
                context.Produtos.Update(Produto);
                await context.SaveChangesAsync();
                return Ok(Produto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Produtos/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Produto = await context
                .Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (Produto == null)
                return NotFound();

            try
            {
                context.Produtos.Remove(Produto);
                await context.SaveChangesAsync();
                return Ok($"Id: {Produto.Id}");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}