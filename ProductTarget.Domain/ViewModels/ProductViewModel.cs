using System.ComponentModel.DataAnnotations;

namespace Management.Domain.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Informe a descrição")]
        [MaxLength(255, ErrorMessage = "Descrição excede o limite de 255 caracteres")]
        [MinLength(2, ErrorMessage = "Informe uma descrição de pelo menos 2 caracteres")]
        public string Description { get; set; }
        [MaxLength(20, ErrorMessage = "Descrição curta excede o limite de 20 caracteres")]
        public string ShortDescription { get; set; }
        [Range(0, 1000, ErrorMessage = "Quantidade permitida entre 0 e 1000")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Informe um valor")]
        [Range(0.1, 1000, ErrorMessage = "Valor do produto deve ser entre 0.1 e 1000")]
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public long CategoryId { get; set; }
    }
}
