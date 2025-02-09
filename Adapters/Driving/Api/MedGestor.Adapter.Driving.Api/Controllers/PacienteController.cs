using MedGestor.Adapter.Driving.Api.AppService.Interfaces;
using MedGestor.Adapter.Driving.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedGestor.Adapter.Driving.Api.Controllers;

[ApiController]
[Route("Paciente")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteAppService _pacienteAppService;

    public PacienteController(IPacienteAppService pacienteAppService)
    {
        _pacienteAppService = pacienteAppService;
    }
    
    [HttpPost]
    [Route("Cadastrar")]
    [Authorize(Roles = "0")]
    [ProducesResponseType(typeof(Ok<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] IncluirPacienteViewModel incluirPacienteViewModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.Values);

        var agenda = await _pacienteAppService.IncluirPacienteAsync(incluirPacienteViewModel);

        return agenda ? Ok(true) : BadRequest("Falha ao Cadastrar Paciente");
    }
}