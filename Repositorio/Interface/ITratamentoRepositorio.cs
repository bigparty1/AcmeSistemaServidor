using AcmeSistemaServidor.Data.Models;
using AcmeSistemaServidor.Data.Models.Entities;

namespace AcmeSistemaServidor.Repositorio.Interface
{
    public interface ITratamentoRepositorio
    {
        public Task<ResultadoPaginado<Tratamento>> PegarTratamentosAsync(bool status, int idPaciente, DateTime dataInicial, DateTime dataFinal, int pagina, int quantidadePorPagina);

        public Task AdicionarTratamentoAsync(Tratamento tratamento);

        public Task AtualizarTratamentoAsync(Tratamento tratamento);
    }
}
