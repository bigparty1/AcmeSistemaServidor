using AcmeSistemaServidor.Data.Models;
using AcmeSistemaServidor.Data.Models.Entities;

namespace AcmeSistemaServidor.Repositorio.Interface
{
    public interface IPacienteRepositorio
    {
        public Task<ResultadoPaginado<Paciente>> PegarPacientesAsync(bool status, string nomePrefixo, int pagina, int quantidadePorPagina);

        public Task AdicionarPacienteAsync(Paciente paciente);

        public Task AtualizarPacienteAsync(Paciente paciente);
    }
}
