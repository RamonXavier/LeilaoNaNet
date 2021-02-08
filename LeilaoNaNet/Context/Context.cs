using System.Data.Entity;

namespace LeilaoNaNet.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("Leilao")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Lances> Lances{ get; set; }
        public DbSet<ImagemProduto> ImagemProdutos { get; set; }
    }
}