using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CerquinT3Tarjeta.Models
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public int TarjetaId { get; set; }

    }
}