using Microsoft.EntityFrameworkCore;

namespace SmartDonnes_Api
{

    public class MyDataContext : DbContext
    {
        public MyDataContext() { }
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options) { }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Avaliacao>? Avaliacoes { get; set; }
        public DbSet<ClienteAvaliacao>? ClientesAvaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteAvaliacao>().HasKey(k => new {
                k.ClienteId,
                k.AvaliacaoId
            });
        }
    }
}