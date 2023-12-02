using Microsoft.AspNetCore.Mvc;
using RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase;
using RpcCalc.Domain.Interop.Permissao;

namespace RpcCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        [HttpPost]
        [Route("gravar")]
        public async Task<IActionResult> Gravar([FromServices] IPermissaoCreate useCase, [FromBody] PermissaoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(viewModel);

            return Ok(result);
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir([FromServices] IPermissaoDelete useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Execute(id);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("obterTodos")]
        public async Task<IActionResult> ObterTodos([FromServices] IPermissaoSearch useCase)
        {
            var result = await useCase.Listar();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromServices] IPermissaoSearch useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Capturar(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
