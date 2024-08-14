using AcmeSistemaServidor.Data.Contexto;
using AcmeSistemaServidor.Data.Models;
using AcmeSistemaServidor.Data.Models.Entities;
using AcmeSistemaServidor.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace AcmeSistemaServidor.Repositorio
{
    public class TratamentoRepositorio : ITratamentoRepositorio
    {
        private readonly AcmeSistemaContexto _contexto;

        public TratamentoRepositorio(AcmeSistemaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarTratamentoAsync(Tratamento tratamento)
        {
            var paciente = await _contexto.Pacientes.FindAsync(tratamento.IdPaciente);
            tratamento.Paciente = paciente;
            await _contexto.Tratamentos.AddAsync(tratamento);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarTratamentoAsync(Tratamento tratamento)
        {
            _contexto.Tratamentos.Update(tratamento);
            await _contexto.SaveChangesAsync();
        }

        public async Task<ResultadoPaginado<Tratamento>> PegarTratamentosAsync(bool status, int idPaciente, DateTime dataInicial, DateTime dataFinal, int pagina, int quantidadePorPagina)
        {
            dataInicial = dataInicial.Date;         //00:00
            dataFinal = dataFinal.Date.AddDays(1);

            var query = _contexto.Tratamentos.Where(t => t.Status == status)
                                             .Where(t => t.IdPaciente == idPaciente) 
                                             .Where(t => t.Date >= dataInicial && t.Date < dataFinal)
                                             .OrderByDescending(t => t.Date);

            return new ResultadoPaginado<Tratamento>
            {
                TotalItems = await query.CountAsync(),
                Items = await query.Skip((pagina - 1) * quantidadePorPagina)
                                   .Take(quantidadePorPagina)
                                   .ToListAsync(),
                PaginaAtual = pagina,
                TotalPorPaginas = quantidadePorPagina
            };
        }
    }
}
