using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedGestor.Adapter.Driving.Api.Controllers;

[ApiController]
[Route("Agenda")]
public class AgendaController : ControllerBase
{
    private readonly IAgendaAppService _agendaAppService;

    public AgendaController(IAgendaAppService agendaAppService)
    {
        _agendaAppService = agendaAppService;
    }
    
    [HttpGet]
    [Route("PorId/{id:guid}")]
    [ProducesResponseType(typeof(Ok<AgendaViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var response = await _agendaAppService.ObterAgendaPorId(id);
        return response is not null ? Ok(response) : NotFound();
    }
    
    [HttpGet]
    [Route("PorMedicoId/{medicoId:guid}")]
    [ProducesResponseType(typeof(Ok<AgendaViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPorMedicoId([FromRoute] Guid medicoId)
    {
        var response = await _agendaAppService.ObterAgendasPorMedicoId(medicoId);
        return response.Any() ? Ok(response) : NotFound();
    }
    
    [HttpPost]
    [Route("Cadastrar")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] IEnumerable<IncluirAgendaViewModel> agendaViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.Values);

        var agenda = await _agendaAppService.IncluirAgendas(agendaViewModel);

        return agenda ? Ok(true) : BadRequest("Falha ao Cadastrar Agendas");
    }
    
    
    [HttpPut]
    [Route("Atualizar")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] AtualizarAgendaViewModel atualizarAgendaViewModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        var agendaAtualizada = await _agendaAppService.AtualizarAgenda(atualizarAgendaViewModel);

        return agendaAtualizada ? Ok(true) : BadRequest("Falha ao Atualizar Agenda");
    }
    
    [HttpDelete]
    [Route("Remover/{id:guid}")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var agendaRemovida = await _agendaAppService.RemoverAgendaPorId(id);
        return agendaRemovida ? Ok(true) : BadRequest("Falha ao Remover Agenda");
    }
}