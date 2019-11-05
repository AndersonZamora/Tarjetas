using CerquinT3Tarjeta.DB.Maps;
using CerquinT3Tarjeta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CerquinT3Tarjeta.DB
{
    public class SimuladorContext : DbContext
    {
        public IDbSet<Tarjeta> Tarjetas { get; set; }
        public IDbSet<Gasto> Gastos { get; set; }
        //public IDbSet<TarjetaGasto> TarjetaGastos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TarjetaMap());
            modelBuilder.Configurations.Add(new GastoMap());
            //modelBuilder.Configurations.Add(new TarjetaGastomap());
        }
    }
}