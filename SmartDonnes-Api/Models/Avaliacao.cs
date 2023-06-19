using System.Collections.Generic;

namespace SmartDonnes_Api
{

    public class Avaliacao
    {
        public Avaliacao() { }
        public int Id { get; set; }
        public DateTime MesAnoRef { get; set; }
        public int ClienteId { get; set; }
        public int Nota { get; set; }
        public string? MotivoNota { get; set; }
        public IEnumerable<ClienteAvaliacao>? ClienteAvaliacao { get; set; }
    }
}