using System.ComponentModel.DataAnnotations;

namespace GestaoDocumento.Models
{
    public class Documento
    {
        public enum RevisaoEnum { [Display(Name = "0")]_0, A, B, C, D, E, F, G }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Revisão")]
        public RevisaoEnum Revisao { get; set; }
        [Required]
        [Display(Name = "Data Planejada")]
        [DataType(DataType.Date)]
        public DateTime DataPlanejada { get; set; }
        [Required]
        public decimal Valor { get; set; }

    }
}
