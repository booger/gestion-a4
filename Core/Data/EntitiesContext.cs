using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options) 
          : base(options)
        {
        }

        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasKey(s =>
              new { s.ArticuloID, s.DepositoID });
        }
    }
}
