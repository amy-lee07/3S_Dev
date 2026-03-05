using Filmes.WebAPI.DTO;
using Filmes.WebAPI.Intterface;
using Filmes.WebAPI.Intterface;
using Filmes.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Filmes.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public IActionResult Login(LoginDTO loginDto)
    {
        try
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDto.Email, loginDto.Senha!);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha inválidos!");
            }

            //Caso encontre o usuario, prosseguir para criacao do token

            //1 - Definir as informações(Claims) que serão fornecidas no token(Payload)

            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario),

                new Claim (JwtRegisteredClaimNames.Email, usuarioBuscado.Email!)

                //existe a possibilidade de criar uma claim personalizada
                //new Claim ("ClaimPersonalizada", "Valor da claim personalizada")
            };

            //2 - Definir a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

            //3 - Definir as credenciais do token (Header)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //4 - Gerar o token
            var token = new JwtSecurityToken(
                issuer: "api_filmes", //Emissor do token
                audience: "api_filmes", //Destinatário do token
                claims: claims, //Informações definidas no passo 1
                expires: DateTime.Now.AddMinutes(5), //Tempo de expiração do token
                signingCredentials: creds //Credenciais do token (definidas no passo 3)
            );
            //5- retornar o token criado
            return Ok(new
               {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo //Data de expiração do token
            });

        }
        catch (Exception)
        {

            throw;
        }
    }
}