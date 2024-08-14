namespace AcmeSistemaServidor.Data.Models
{
    public class ResultadoPaginado <T>
    {
        public required ICollection<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPorPaginas { get; set; }
    }
}
