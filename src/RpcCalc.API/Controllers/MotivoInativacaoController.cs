using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpcCalc.Domain.Interfaces.UseCases.MotivoInativacaoUseCase;
using RpcCalc.Domain.Interop.MotivoInativacao;

namespace RpcCalc.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoInativacaoController : ControllerBase
    {
        [HttpPost]
        [Route("gravar")]
        public async Task<IActionResult> Gravar([FromServices] IMotivoInativacaoCreate useCase, [FromBody] MotivoInativacaoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(viewModel);

            return Ok(result);
        }

        [HttpGet("obterPorUsuario/{id}")]
        public async Task<IActionResult> ObterPorUsuario([FromServices] IMotivoInativacaoSearch useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Listar(id);
            return Ok(result);
        }
    }
}
