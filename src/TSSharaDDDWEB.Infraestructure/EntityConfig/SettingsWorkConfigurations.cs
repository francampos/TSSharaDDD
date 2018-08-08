using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.EntityConfig
{
    public class SettingsWorkConfigurations : IEntityTypeConfiguration<SettingsWork>
    {
        public SettingsWorkConfigurations()
        {
            ToTable("SettingsWork");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Serial).HasColumnName("Serial").IsOptional().HasMaxLength(15).HasColumnType("VARCHAR");
            Property(x => x.CurrentLanguage).HasColumnName("CurrentLanguage").IsOptional().HasMaxLength(5).HasColumnType("VARCHAR");
            Property(x => x.NetworkFailureTime).HasColumnName("NetworkFailTime").IsOptional();
            Property(x => x.LowBatteryTime).HasColumnName("LowBatteryTime").IsOptional();
            Property(x => x.RestPCTime).HasColumnName("RestPCTime").IsOptional();
            Property(x => x.ShutdownOSAlongWithPCFlag).HasColumnName("ShutdownOSAlongWithPCFlag").IsOptional();
            Property(x => x.StartAppAlongWithAppFlag).HasColumnName("StartAppAlongWithAppFlag").IsOptional();
            Property(x => x.Port).HasColumnName("Port").IsOptional();
            Property(x => x.AutonomyEndTimeFlag).HasColumnName("AutonomyEndTime").IsOptional();
        }

        public void Configure(EntityTypeBuilder<SettingsWork> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
