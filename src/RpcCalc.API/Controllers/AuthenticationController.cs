using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpcCalc.API.Services;
using RpcCalc.Domain.Interfaces.UseCases.AuthenticationUseCase;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Authentication;
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

            UsuarioLogado usuarioAutenticado = new UsuarioLogado();

            var usuarioValildo = await useCase.ValidarLogin(viewModel.Login, viewModel.Senha);

            if (usuarioValildo == null)
            {
                var usuarioErroLogin = new UsuarioLogado { Sucesso = false, Error = "Usuário ou senha inválidos", Token = string.Empty, Usuario = new UsuarioInfo("Anonymous", viewModel.Login, string.Empty) };
                return StatusCode(401, usuarioErroLogin);
            }
            
            var roleCliente = usuarioValildo.Roles.Find(x => x.Role.Nome.Equals("Cliente"));
            
            if (roleCliente == null)
                usuarioAutenticado = tokenService.GerarToken(usuarioValildo);
            else
                usuarioAutenticado = tokenService.GerarToken(usuarioValildo, roleCliente.Role.Nome);

            return Ok(usuarioAutenticado);
        }

        [AllowAnonymous]
        [HttpPost("novaconta")]
        public async Task<IActionResult> NovaConta([FromServices] INovaContaCreate useCase, [FromBody] NovaContaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(viewModel);

            if (result == null)
               return  StatusCode(400, "Este E-mail já está cadastrado");
            
            return Ok(result);
        }
    }
}
