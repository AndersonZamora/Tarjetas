using CerquinT3Tarjeta.DB;
using CerquinT3Tarjeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CerquinT3Tarjeta.Controllers
{
    public class TarjetaGastoController : Controller
    {
        [HttpGet]
        public ActionResult Crear()
        {
            var DBContext = new SimuladorContext();

            ViewBag.Tarjetas = DBContext.Tarjetas.ToList();
            ViewBag.Gastos = DBContext.Gastos.ToList();

            return View();
        }

        //[HttpPost]
        //public ActionResult Crear(List<TarjetaGasto> agregar)
        //{
        //    var DBContext = new SimuladorContext();
        //    if (agregar.Count > 6)
        //    {
        //        ViewBag.Tarjetas = DBContext.Tarjetas.ToList();
        //        ViewBag.Gastos = DBContext.Gastos.ToList();
        //        return View();
        //    }
        //    else
        //    {
        //        foreach (var item in agregar)
        //        {
        //            DBContext.TarjetaGastos.Add(item);
        //        }
        //        DBContext.SaveChanges();
        //    }

        //    return RedirectToAction("Index", "Tarjeta");
        //}
    }
}
