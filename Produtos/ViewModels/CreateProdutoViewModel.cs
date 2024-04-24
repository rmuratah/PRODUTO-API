using System.ComponentModel.DataAnnotations;

namespace Produtos.ViewModels
{
    public class CreateProdutoViewModel
    {
        [Required]
        public string? Nome { get; set; }
        [Required]
        public double? Preco { get; set; }
        [Required]
        public string? Descricao { get; set; }
    }
}