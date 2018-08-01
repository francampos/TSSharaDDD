using Microsoft.EntityFrameworkCore;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.Data
{
    public class NobreakContext : DbContext
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

            #region Configurações de Nobreak
            modelBuilder.Entity<Nobreak>().Property(e => e.Serial)
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Nobreak>().Property(e => e.CompanyName)
                .HasColumnType("varchar(90)")
                .IsRequired();

            modelBuilder.Entity<Nobreak>().Property(e => e.UPSModel)
                .HasColumnType("varchar(20)")
                .IsRequired();

            modelBuilder.Entity<Nobreak>().Property(e => e.Version)
                .HasColumnType("varchar(10")
                .IsRequired();

            modelBuilder.Entity<Nobreak>().Property(e => e.Label)
                .HasColumnType("varchar(20)")
                .IsRequired();
            #endregion

            #region Configurações de Menu
            modelBuilder.Entity<Menu>()
            .HasMany(x => x.SubMenu)
            .WithOne()
            .HasForeignKey(x => x.MenuId);
            #endregion
        }
    }
}
