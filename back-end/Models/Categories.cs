using System.ComponentModel.DataAnnotations;

namespace back_end.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome eh obrigatorio!")]
        [MinLength(5, ErrorMessage = "O nome deve ter pelo menos 5 caracteres!")]
        public string Name { get; set; } = string.Empty;
        public DateTime DateCreate { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}
