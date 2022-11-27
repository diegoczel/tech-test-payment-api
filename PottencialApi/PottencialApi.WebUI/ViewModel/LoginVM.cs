using System.ComponentModel.DataAnnotations;

namespace PottencialApi.WebUI.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "O email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email mal formatado!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(
            20,
            ErrorMessage = "O {0} deve ter ao menos {2} e no maximo {1} char de comprimento.",
            MinimumLength = 10
        )]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
