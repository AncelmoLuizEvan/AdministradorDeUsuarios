using Microsoft.AspNetCore.Mvc;
using RpcCalc.Domain.Interfaces.UseCases.RoleUseCase;

namespace RpcCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpGet("obterTodos")]
        public async Task<IActionResult> ObterTodos([FromServices] IRoleSearch useCase)
        {
            var result = await useCase.Listar();
            return Ok(result);
        }
    }
}
