using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.Repositories
{
    public class NobreakDemandDataConfigurations : IEntityTypeConfiguration<NobreakDemandData>
    {

        public NobreakDemandDataConfigurations()
        {

        }

        public void Configure(EntityTypeBuilder<NobreakDemandData> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
