using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase;
using RpcCalc.Domain.Interop.Perfil;

namespace RpcCalc.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        [HttpPost]
        [Route("gravar")]
        public async Task<IActionResult> Gravar([FromServices] IPerfilCreate useCase, [FromBody] PerfilViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(viewModel);

            return Ok(result);
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Alterar([FromServices] IPerfilUpdate useCase, [FromRoute] Guid id, [FromBody] PerfilViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(id, viewModel);

            return Ok(result);
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir([FromServices] IPerfilDelete useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Execute(id);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpGet("obterTodos")]
        public async Task<IActionResult> ObterTodos([FromServices] IPerfilSearch useCase)
        {
            var result = await useCase.Listar();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromServices] IPerfilSearch useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Capturar(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
