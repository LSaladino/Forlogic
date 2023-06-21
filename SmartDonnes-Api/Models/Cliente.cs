namespace SmartDonnes_Api.Models
{

    public class Cliente
    {
        public Cliente() { }
        public int Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? PessoaContato { get; set; }
        public string? Cnpj { get; set; }
        public DateTime DataCliente { get; set; }
        public IEnumerable<ClienteAvaliacao>? ClienteAvaliacao { get; set; }
    }
}