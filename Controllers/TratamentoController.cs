using AcmeSistemaServidor.Data.Models.Entities;
using AcmeSistemaServidor.Repositorio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcmeSistemaServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamentoController : ControllerBase
    {
        private readonly ITratamentoRepositorio _tratamentoRepositorio;

        public TratamentoController(ITratamentoRepositorio tratamentoRepositorio)
        {
            _tratamentoRepositorio = tratamentoRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> PegarTratamentosAsync(int idPaciente, DateTime dataInicial, DateTime dataFinal, bool status = true, int pagina = 1, int quantidadePorPagina = 20)
        {
            try
            {
                var resultado = await _tratamentoRepositorio.PegarTratamentosAsync(status, idPaciente, dataInicial, dataFinal, pagina, quantidadePorPagina);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTratamentoAsync(Tratamento tratamento)
        {
            try
            {
                await _tratamentoRepositorio.AdicionarTratamentoAsync(tratamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarTratamentoAsync(Tratamento tratamento)
        {
            try
            {
                await _tratamentoRepositorio.AtualizarTratamentoAsync(tratamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
