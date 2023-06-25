namespace SmartDonnes_Api.Models
{

    public class Cliente
    {
        public Cliente() { }
        public Cliente(int id, string RazaoSocial, string PessoaContato, string Cnpj, DateTime dataCliente)
        {
            this.Id = id;
            this.RazaoSocial = RazaoSocial;
            this.PessoaContato = PessoaContato;
            this.Cnpj = Cnpj;
            this.DataCliente = dataCliente;

        }
        public int Id { get; set; }
        public string? RazaoSocial { get; set; }

        public string? PessoaContato { get; set; }

        public string? Cnpj { get; set; }

        public DateTime DataCliente { get; set; }
    }
}