using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeSistemaServidor.Data.Models.Entities
{
    public class Tratamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTratamento { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public Paciente? Paciente { get; set; }
    }
}
