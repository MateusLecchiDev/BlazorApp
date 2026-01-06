using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;
    }
}
