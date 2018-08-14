using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceOsorioManha.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaID{ get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(30, ErrorMessage = "O campo deve ter no maximo 30 caracteres!")]
        [Display(Name = "Nome da descrição")]
        public string Nome { get; set; }

        [Display(Name = "Descrição da categoria")]
        public string Descricao { get; set; }
    }
}