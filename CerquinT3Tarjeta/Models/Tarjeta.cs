using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CerquinT3Tarjeta.Models
{
    public class Tarjeta
    {
        public int IdTarjeta { get; set; }
        public string EntidadFinanciera { get; set; }
        public string NroTarjeta { get; set; }
        public int MesVencimiento { get; set; }
        public int AnoVencimiento { get; set; }
        public IList<Gasto> Gastos { get; set; }


    }
}