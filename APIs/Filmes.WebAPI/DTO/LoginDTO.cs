using System.ComponentModel.DataAnnotations;

namespace Filmes.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O Emial do usuario é obrigatorio!")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "O senha do usuario é obrigatorio!")]
    public string? Senha { get; set; }

}
