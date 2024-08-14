using AcmeSistemaServidor.Data.Contexto;
using AcmeSistemaServidor.Data.Models;
using AcmeSistemaServidor.Data.Models.Entities;
using AcmeSistemaServidor.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace AcmeSistemaServidor.Repositorio
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly AcmeSistemaContexto _contexto;

        public PacienteRepositorio(AcmeSistemaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarPacienteAsync(Paciente paciente)
        {
            var pacienteExistente = await _contexto.Pacientes.FirstOrDefaultAsync(p => p.CPF == paciente.CPF);

            if (pacienteExistente != null)
            {
                throw new Exception($"CPF cadastrado no paciente {pacienteExistente.Nome}");
            }

            await _contexto.Pacientes.AddAsync(paciente);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarPacienteAsync(Paciente paciente)
        {
            try
            {
                _contexto.Pacientes.Update(paciente);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    throw;

                if (ex.InnerException.Message.Contains("23505")) //msg de erro de unique postgresql
                    throw new Exception($"CPF cadastrado no paciente {paciente.Nome}");
                else
                    throw;
            }
        }

        public async Task<ResultadoPaginado<Paciente>> PegarPacientesAsync(bool status, string nomePrefixo, int pagina, int quantidadePorPagina)
        {
            var query = _contexto.Pacientes.Where(p => EF.Functions.ILike(p.Nome, $"{nomePrefixo}%"))
                                           .Where(p => p.Ativo == status)
                                           .OrderBy(p => p.Nome);

            return new ResultadoPaginado<Paciente>
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
