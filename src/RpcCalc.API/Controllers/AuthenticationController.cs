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
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromServices] TokenService tokenService,
            [FromServices] IUsuarioSearch useCase,
            [FromBody] LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioValildo = await useCase.ValidarLogin(viewModel.Login, viewModel.Senha);

            if (usuarioValildo == null)
            {
                var usuarioErroLogin = new UsuarioLogado { Sucesso = false, Error = "Usuário ou senha inválidos", Token = string.Empty, Usuario = new UsuarioInfo("Anonymous", viewModel.Login) };
                return StatusCode(401, usuarioErroLogin);
            }
   
            var usuarioAutenticado = tokenService.GerarToken(usuarioValildo);

            return Ok(usuarioAutenticado);
        }

        [AllowAnonymous]
        [HttpPost("novaconta")]
        public async Task<IActionResult> NovaConta([FromServices] IUsuarioCreate useCase, [FromBody] NovaContaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.ExecuteNovaConta(viewModel);

            return Ok(result);
        }
    }
}
