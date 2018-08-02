using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.EntityConfig
{
    public class NobreakMap : IEntityTypeConfiguration<Nobreak>
    {
        public void Configure(EntityTypeBuilder<Nobreak> builder)
        {
            throw new NotImplementedException();
        }
    }
}
