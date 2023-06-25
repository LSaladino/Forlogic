using System.Collections.Generic;

namespace SmartDonnes_Api.Models
{

    public class Avaliacao
    {
        public Avaliacao() { }
        public Avaliacao(int id, DateTime mesAno, int Nota, string motivoAvaliacao)
        {
            this.Id = id;
            this.mesAno = mesAno;
            this.notaAvaliacao = notaAvaliacao;
            this.motivoAvaliacao = motivoAvaliacao;
        }
        public int Id { get; set; }
        public DateTime mesAno { get; set; }
        public int notaAvaliacao { get; set; }
        public string? motivoAvaliacao { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<ClienteAvaliacao>? clientesAvaliados { get; set; }
    }
}