using DDDCommerceBCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDCommerceBCC.Infra
{
    public class SqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
