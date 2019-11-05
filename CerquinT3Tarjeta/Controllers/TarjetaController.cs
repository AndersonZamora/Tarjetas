using CerquinT3Tarjeta.DB;
using CerquinT3Tarjeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace CerquinT3Tarjeta.Controllers
{
    public class TarjetaController : Controller
    {
        // GET: Tarjeta
        public ActionResult IndexTabla(string EntidadFinanciera)
        {
            var DBContext = new SimuladorContext();
            if (string.IsNullOrEmpty(EntidadFinanciera))
            {
                var Tarjetas = DBContext.Tarjetas.Include(a => a.Gastos).ToList();
                return View(Tarjetas);
            }
            else
            {
                var Tarjetas = DBContext.Tarjetas.Where(o => o.EntidadFinanciera.Contains(EntidadFinanciera)).Include(a => a.Gastos);
                return View(Tarjetas);
            }
        }
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Crear(Tarjeta tarjeta)
        {
            Validar(tarjeta);
            if (ModelState.IsValid)
            {
                var DBContext = new SimuladorContext();
                DBContext.Tarjetas.Add(tarjeta);
                DBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarjeta);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View(new Tarjeta());
        }
        private void Validar(Tarjeta tarjeta)
        {
            if (tarjeta.EntidadFinanciera == null || tarjeta.EntidadFinanciera == "")
                ModelState.AddModelError("EntidadFinanciera", "La Entidad Financiera es invalida");

            if (tarjeta.NroTarjeta == null || tarjeta.NroTarjeta == "" || tarjeta.NroTarjeta == "1,2,3,4,5,6,7,8,9")
                ModelState.AddModelError("NroTarjetas", "Solo Numeros");

            if (tarjeta.AnoVencimiento <= 2019 || tarjeta.AnoVencimiento >= 9999 || tarjeta.AnoVencimiento < 0)
                ModelState.AddModelError("Ano", "El año debe ser meyor a 2019");

            if (tarjeta.MesVencimiento <= 1 || tarjeta.MesVencimiento >= 12 || tarjeta.MesVencimiento < 0)
                ModelState.AddModelError("Mes", "El Mes desde 1 a 12");

        }
    }
}