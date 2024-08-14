using AcmeSistemaServidor.Data.Models.Entities;
using AcmeSistemaServidor.Repositorio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcmeSistemaServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> PegarPacientesAsync(bool status = true, string nomePrefixo = "", int pagina = 1, int quantidadePorPagina = 20)
        {
            try
            {
                var resultado = await _pacienteRepositorio.PegarPacientesAsync(status, nomePrefixo, pagina, quantidadePorPagina);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPacienteAsync(Paciente paciente)
        {
            try
            {
                await _pacienteRepositorio.AdicionarPacienteAsync(paciente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPacienteAsync(Paciente paciente)
        {
            try
            {
                await _pacienteRepositorio.AtualizarPacienteAsync(paciente);
                return Ok();
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                    return BadRequest(ex.InnerException.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
