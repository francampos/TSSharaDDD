using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.EFRepository
{
    public class SettingsWorkRepository : IEntityTypeConfiguration<SettingsWork>
    {
        public void Configure(EntityTypeBuilder<SettingsWork> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
