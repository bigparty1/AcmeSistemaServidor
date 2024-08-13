using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeSistemaServidor.Data.Models.Entities
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateOnly Nascimento { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Rua { get; set; }

        public string Complemento { get; set; }

        [Required]
        public  bool Ativo { get; set; }
    }
}
