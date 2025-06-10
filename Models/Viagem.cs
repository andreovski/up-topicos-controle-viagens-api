using System.ComponentModel.DataAnnotations;

namespace ControleViagensApi.Models
{
    public class Viagem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Destino { get; set; }

        [Required]
        public DateTime DataPartida { get; set; }

        public DateTime DataRetorno { get; set; }

        [Required]
        public required string NomeViajante { get; set; }

        [Range(0, double.MaxValue)]
        public double Preco { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}