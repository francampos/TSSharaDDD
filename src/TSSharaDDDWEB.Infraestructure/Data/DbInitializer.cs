using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.Infraestructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NobreakContext context)
        {

            if (context.Nobreaks.Any())
            {
                return;
            }

            var nobreaks = new Nobreak[]
            {
                new Nobreak {
                    //Dados de entrada do Nobreak, repetir...
                }
            };
        }
    }
}
