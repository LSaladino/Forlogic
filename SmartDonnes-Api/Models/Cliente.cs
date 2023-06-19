namespace SmartDonnes_Api{

    public class Cliente{
        public Cliente() { }
        public int Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? PessoaContato { get; set; }
        public DateTime DataCliente { get; set; }
        public IEnumerable<ClienteAvaliacao>? ClienteAvaliacao { get; set; }
    }
}