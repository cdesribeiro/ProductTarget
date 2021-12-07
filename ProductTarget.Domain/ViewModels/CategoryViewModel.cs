using System.ComponentModel.DataAnnotations;

namespace Management.Domain.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Informe o Código da Categoria")]
        [MaxLength(3, ErrorMessage = "Código Excede o limite de 3 caracteres")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Informe da Descrição")]
        [MaxLength(50, ErrorMessage = "Descrição Excede o limite de 50 caracteres")]
        public string Description { get; set; }
    }
}
