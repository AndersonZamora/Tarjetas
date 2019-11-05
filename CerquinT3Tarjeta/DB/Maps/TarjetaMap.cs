using CerquinT3Tarjeta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CerquinT3Tarjeta.DB.Maps
{
    public class TarjetaMap : EntityTypeConfiguration<Tarjeta>
    {
        public TarjetaMap()

        {
            ToTable("Tarjeta");
            HasKey(o => o.IdTarjeta);
           
        }
    }
}