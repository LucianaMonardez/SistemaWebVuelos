using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        VuelosDbContext context = new VuelosDbContext();
        // GET: Vuelo
        public ActionResult Index()
        {
            var vuelos = context.Vuelos.ToList();
            return View(vuelos);
        }

        //detalle vuelo

        public ActionResult Detail(int id)
        {
            var vuelo = context.Vuelos.Find(id);

            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }


        //agregar vuelo
        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }

        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.Vuelos.Add(vuelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", vuelo);

            }
        }
        //editar vuelo NO FUNCIONA
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            return View("Edit", vuelo);
        }

        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.Entry(vuelo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", vuelo);
            }
            
        }

        //eliminar vuelo
        public ActionResult Delete(int id)
        {
            var vuelo = context.Vuelos.Find(id);
            if (vuelo != null)
            {
                return View("DeleteConfirm", vuelo);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var vuelo = context.Vuelos.Find(id);
            if (vuelo != null)
            {

                context.Vuelos.Remove(vuelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vuelo);
        }
        //traer por destino

        public ActionResult TraerPorDestino(string destino)
        {
            List<Vuelo> vuelo = (from a in context.Vuelos where a.Destino == destino select a).ToList();
            return View("Index", vuelo);
        }

        //matricula por matricula

        public ActionResult TraerPorMatricula(string matricula)
        {
            Vuelo vuelo = (from a in context.Vuelos where a.Matricula == matricula select a).FirstOrDefault();
            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

    }
}