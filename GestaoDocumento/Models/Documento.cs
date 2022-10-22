namespace GestaoDocumento.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public char Revisao { get; set; }
        public DateTime DataPlanejada { get; set; }
        public decimal Valor { get; set; }

    }
}
