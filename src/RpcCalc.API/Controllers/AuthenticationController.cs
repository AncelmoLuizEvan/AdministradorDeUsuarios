using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpcCalc.API.Services;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromServices] TokenService tokenService,
            [FromServices] IUsuarioSearch useCase,
            [FromBody] LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioLogado = await useCase.ValidarLogin(viewModel.Email, viewModel.Senha);

            if (usuarioLogado == null)
                return NotFound("Usuário ou senha inválida!");

            var token = tokenService.GerarToken(usuarioLogado);

            return Ok(token);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("obterUsuario")]
        public IActionResult ObterUsuario() => Ok(User.Identity.Name);

        [Authorize(Roles = "cliente")]
        [HttpGet("obterCliente")]
        public IActionResult ObterCliente() => Ok(User.Identity.Name);
    }
}
