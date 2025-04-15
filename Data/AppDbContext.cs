using Microsoft.EntityFrameworkCore;
using ApiCrud.Models;

namespace ApiCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
