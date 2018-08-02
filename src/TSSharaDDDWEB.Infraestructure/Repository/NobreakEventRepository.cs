using TSSharaDDDWEB.ApplicationCore.Entity;
using TSSharaDDDWEB.ApplicationCore.Interfaces.Repository;
using TSSharaDDDWEB.Infraestructure.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TSSharaDDDWEB.Infraestructure.EFRepository
{
    public class NobreakEventRepository : EFRepository<NobreakEvent>, INobreakEventRepository
    {

        public NobreakEventRepository(NobreakContext dbContext) : base(dbContext)
        {

        }

    }
}
