using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.Repositories
{
    public class SettingsWorkConfigurations : IEntityTypeConfiguration<SettingsWork>
    {
        public SettingsWorkConfigurations()
        {

        }

        public void Configure(EntityTypeBuilder<SettingsWork> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
