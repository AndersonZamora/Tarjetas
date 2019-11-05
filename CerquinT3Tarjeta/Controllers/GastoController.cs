using CerquinT3Tarjeta.DB;
using CerquinT3Tarjeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CerquinT3Tarjeta.Controllers
{
    public class GastoController : Controller
    {
        // GET: Gasto
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Gasto gasto)
        {
            var DBContext = new SimuladorContext();
            ViewBag.Tarjeta = DBContext.Tarjetas;

            Validar(gasto);
            if (ModelState.IsValid)
            {
               
                DBContext.Gastos.Add(gasto);
                DBContext.SaveChanges();
                return RedirectToActionPermanent("Index", "Tarjeta");
            }
            return View("Crear");
        }

        [HttpGet]
        public ActionResult Crear()
        {
            var DBContext = new SimuladorContext();
            ViewBag.Tarjeta = DBContext.Tarjetas;

            return View(new Gasto());
        }
        private void Validar(Gasto gasto)
        {
            if (gasto.Monto < 0)
                ModelState.AddModelError("Monto", "El gasto debe ser mayo a 0");

            if (gasto.Fecha == null)
                ModelState.AddModelError("Fecha", "Fecha Obligatoria");

            if (gasto.Descripcion == null)
                ModelState.AddModelError("Descripcion", "Descripcion Obligatoria");
        }
    }
}