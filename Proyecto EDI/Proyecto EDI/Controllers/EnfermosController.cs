using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_EDI.Helpers;
using Proyecto_EDI.Models;
using Estructuras; 
namespace Proyecto_EDI.Controllers
{
    public class EnfermosController : Controller
    {
        public static List<Enfermos> ListaContagiado = new List<Enfermos>();
        public List<Simulacion> simulacions = new List<Simulacion>();
        // GET: Enfermos
        public ActionResult Index()
        {
            return View(Storage.Instancia.ListaContagiado);
        }

        // GET: Enfermos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Enfermos/Create
        public ActionResult Create()
        {
            var list = new List<string>() { "Capital", "Quetzaltenango", "Escuintla", "Oriente","Petén" };
            ViewBag.list = list;
            var list2 = new List<string>() { "Fraijanes", "Los esclavos", "Villa santorini" };
            ViewBag.list2 = list2;
            //if (ViewBag.list == "Capital")
            //{
            //    //Simulacion del examen 
            
            return View();
        }
        
        // POST: Enfermos/Create
        [HttpPost]
        public ActionResult Create(Enfermos enfermos)
        {
            Enfermos[] datosenfermo = ListaContagiado.ToArray();
            
            ListaContagiado.Add(enfermos);
            if (enfermos.Save())
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View(enfermos);
            }
            
            //return RedirectToAction("Create");
            //Enfermos[] enfermoscont = ListaContagiado.ToArray();
            //try
            //{
            //    var contagiado = new Enfermos
            //    {
            //        Nombre = collection["Nombre"],
            //        Apellido = collection["Apellido"],
            //        Departamento = collection["Departamento"],
            //        Municipio = collection["Municipio"],
            //        Dpi = Convert.ToInt32(collection["DPI"]),
            //        PartidaN = Convert.ToInt32(collection["Partida de nacimiento"]),
            //        Fecha = Convert.ToInt32(collection["Fecha de entrada"]),
            //        Edad = Convert.ToInt32(collection["Edad"]),
            //        Hora = Convert.ToInt32(collection["Hora de entrada"])
            //    };
            //    ListaContagiado.Add(contagiado);
            //    if (contagiado.Save())
            //    {
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        return View(contagiado);
            //    }
            //}
            //catch 
            //{
            //    return View();
               
            //}
        
        }
        public ActionResult Simulacion(Simulacion sim, Enfermos enfermos)
        {
            if (enfermos.Edad >= 60)
            {
                sim.Contagiado();
                Console.WriteLine("Pertenece a la tercera edad"); //agregar la simulacion de el examen y definir las edades en este controlador 
            }
            sim.Contagiado();
            return RedirectToAction("Create");
            //implementacion para la tabla hash 
            //Dictionary<string, string> diccionario = new Dictionary<string, string>();
            //diccionario.Add(enfermos.Nombre, enfermos.Sintoma); // uno sirve de clave y el otro de valor, cambiarlo por int para poder ingresar lel valor como la hora de ingreso para que sea mas facil su reconocimiento
        }
        // GET: Enfermos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Enfermos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enfermos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Enfermos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
