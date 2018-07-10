using Microsoft.EntityFrameworkCore;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.Data
{
    public class NobreakContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public NobreakContext(DbContextOptions<NobreakContext> options) : base(options)
        {

        }

        public DbSet<Nobreak> Nobreaks { get; set; }
        public DbSet<NobreakEvent> NobreakEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nobreak>().ToTable("Nobreak");
            modelBuilder.Entity<NobreakEvent>().ToTable("NobreakEvent");
        }
    }
}
