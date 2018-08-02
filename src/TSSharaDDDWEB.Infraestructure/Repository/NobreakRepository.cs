using TSSharaDDDWEB.ApplicationCore.Entity;
using TSSharaDDDWEB.ApplicationCore.Interfaces.Repository;
using TSSharaDDDWEB.Infraestructure.Data;
using System.Linq;

namespace TSSharaDDDWEB.Infraestructure.EFRepository
{
    public class NobreakRepository : EFRepository<Nobreak>, INobreakRepository
    {

        public NobreakRepository(NobreakContext dbContext) : base(dbContext)
        {

        } 
    }
}
