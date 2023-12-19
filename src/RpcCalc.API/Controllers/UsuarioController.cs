using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("gravar")]
        public async Task<IActionResult> Gravar([FromServices] IUsuarioCreate useCase, [FromBody] UsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(viewModel);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Alterar([FromServices] IUsuarioUpdate useCase, [FromRoute] Guid id, [FromBody] UsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(id, viewModel);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir([FromServices] IUsuarioDelete useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Execute(id);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{idusuario}/role/{idrole}/excluirRole")]
        public async Task<IActionResult> ExcluirRole([FromServices] IUsuarioDelete useCase, [FromRoute] Guid idusuario, [FromRoute] Guid idrole)
        {
            var result = await useCase.Execute(idusuario, idrole);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("obterTodos")]
        public async Task<IActionResult> ObterTodos([FromServices] IUsuarioSearch useCase)
        {
            var result = await useCase.Listar();
            return Ok(result);
        }

        [Authorize(Roles = "Admin, Cliente")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromServices] IUsuarioSearch useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Capturar(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("excluir/usuario/{idusuario}/perfil/{idperfil}/permissao/{idpermissao}")]
        public async Task<IActionResult> Excluir([FromServices] IUsuarioDelete useCase, [FromRoute] Guid idusuario, [FromRoute] Guid idperfil, [FromRoute] Guid idpermissao)
        {
            var result = await useCase.Execute(idusuario, idperfil, idpermissao);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [Authorize(Roles = "Cliente")]
        [HttpPost("cliente")]
        public async Task<IActionResult> ObterClientePorEmail([FromServices] IUsuarioSearch useCase, [FromBody] EmailViewModel email)
        {
            var result = await useCase.ObterPorEmail(email.Email);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
