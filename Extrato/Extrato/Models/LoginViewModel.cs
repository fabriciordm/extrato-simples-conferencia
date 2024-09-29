using System.ComponentModel.DataAnnotations;

namespace Extrato.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Banco é obrigatório.")]
        public string Banco { get; set; }

        [Required(ErrorMessage = "O campo Agência é obrigatório.")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }

}
