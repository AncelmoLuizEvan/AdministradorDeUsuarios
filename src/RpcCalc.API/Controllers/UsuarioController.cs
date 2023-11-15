﻿using Microsoft.AspNetCore.Mvc;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("gravar")]
        public async Task<IActionResult> Gravar([FromServices] IUsuarioCreate useCase, [FromBody] UsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(viewModel);

            return Ok(result); //
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Alterar([FromServices] IUsuarioUpdate useCase, [FromRoute] Guid id, [FromBody] UsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await useCase.Execute(id, viewModel);

            return Ok(result);
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir([FromServices] IUsuarioDelete useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Execute(id);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("obterTodos")]
        public async Task<IActionResult> ObterTodos([FromServices] IUsuarioSearch useCase)
        {
            var result = await useCase.Listar();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromServices] IUsuarioSearch useCase, [FromRoute] Guid id)
        {
            var result = await useCase.Capturar(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
