using System.ComponentModel.DataAnnotations;

namespace GeekStore.Core.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        //[MaxLength(50, ErrorMessage = "A propriedade {0} deve conter entre {1} e {2} caracteres"), MinLength(2)]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? ConfirmPassword { get; set; }
    }
}
