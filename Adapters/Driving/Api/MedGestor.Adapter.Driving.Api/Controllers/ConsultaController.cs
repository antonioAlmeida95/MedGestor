using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedGestor.Adapter.Driving.Api.Controllers;

[ApiController]
[Route("Consulta")]
public class ConsultaController : ControllerBase
{
    private readonly IConsultaAppService _consultaAppService;

    public ConsultaController(IConsultaAppService consultaAppService)
    {
        _consultaAppService = consultaAppService;
    }
    
    [HttpGet]
    [Route("PorFiltro")]
    [Authorize(Roles = "0,1,4")]
    [ProducesResponseType(typeof(Ok<IEnumerable<ConsultaViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPorFiltroId([FromQuery] Guid? medicoId, [FromQuery] Guid? pacienteId = null)
    {
        var response = await _consultaAppService.ObterConsultasPorFiltrosAsync(medicoId, pacienteId);
        return response.Any() ? Ok(response) : NotFound();
    }
    
    [HttpPost]
    [Route("Cadastrar/{agendaId:Guid}")]
    [Authorize(Roles = "0,2")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromRoute] Guid agendaId)
    {
        var agenda = await _consultaAppService.IncluirConsultaAsync(agendaId);
        return agenda ? Ok(true) : BadRequest("Falha ao Cadastrar Consulta");
    }
    
    
    [HttpPatch]
    [Route("AceitarConsulta")]
    [Authorize(Roles = "5")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Patch([FromQuery] Guid consultaId, [FromQuery] bool aceite)
    {
        var consultaAceita = await _consultaAppService.AceitarRecusarConsultaAsync(consultaId, aceite);

        return consultaAceita ? Ok(true) : BadRequest("Falha ao Aceitar/Recusar Consulta");
    }
    
    [HttpPatch]
    [Route("CancelarConsulta")]
    [Authorize(Roles = "2")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PatchCancelaConsulta([FromBody] CancelarConsultaViewModel cancelarConsultaViewModel)
    {
        var consultaCancelada = await _consultaAppService.CancelarConsultaAsync(cancelarConsultaViewModel);

        return consultaCancelada ? Ok(true) : BadRequest("Falha ao Cancelar Consulta");
    }
}