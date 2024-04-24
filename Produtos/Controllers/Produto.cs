using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    }
}