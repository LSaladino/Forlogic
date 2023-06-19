namespace SmartDonnes_Api
{

    public class ClienteAvaliacao
    {
        public ClienteAvaliacao() { }

        public ClienteAvaliacao(int clienteId, int avaliacaoId)
        {
            this.ClienteId = clienteId;
            this.AvaliacaoId = avaliacaoId;

        }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int AvaliacaoId { get; set; }
        public Avaliacao? Avaliacao { get; set; }
    }
}