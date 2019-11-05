using CerquinT3Tarjeta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CerquinT3Tarjeta.DB.Maps
{
    public class GastoMap : EntityTypeConfiguration<Gasto>
    {
        public GastoMap()

        {
            ToTable("Gasto");
            HasKey(o => o.IdGasto);

            HasRequired(p => p.Tarjeta)
               .WithMany(a => a.Gastos)
               .HasForeignKey(o => o.TarjetaId);
        }
    }
}