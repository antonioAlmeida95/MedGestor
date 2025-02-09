using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedGestor.Adapter.Driving.Api.Controllers;

[ApiController]
[Route("Medico")]
public class MedicoController : ControllerBase
{
    private readonly IMedicoAppService _medicoAppService;

    public MedicoController(IMedicoAppService medicoAppService)
    {
        _medicoAppService = medicoAppService;
    }
    
    [HttpPost]
    [Route("Cadastrar")]
    [Authorize(Roles = "0")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] IncluirMedicoViewModel incluirMedicoViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.Values);

        var agenda = await _medicoAppService.IncluirMedicoAsync(incluirMedicoViewModel);
        return agenda ? Ok(true) : BadRequest("Falha ao Cadastrar Medico");
    }
    
    
    [HttpGet]
    [Route("Consultar")]
    [Authorize(Roles = "1,4,0")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] string? especialidade,
        [FromQuery] string? crm, [FromQuery] string? nome)
    {
        var medicos = await _medicoAppService.ObterMedicosPorFiltrosAsync(especialidade, nome, crm); 
        return medicos.Any() ? Ok(medicos) : NoContent();
    }
}