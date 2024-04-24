using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Produtos.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
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
    }
}