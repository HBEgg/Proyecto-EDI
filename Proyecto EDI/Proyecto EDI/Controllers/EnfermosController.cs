using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_EDI.Helpers;
using Proyecto_EDI.Models;
using Estructuras;
using DotNet.Highcharts;
using System.IO;
namespace Proyecto_EDI.Controllers
{
    public class EnfermosController : Controller
    {
       // public static Estructuras.Cola<Enfermosinfo> cola = new Estructuras.Cola<Enfermosinfo>();
        public static List<Enfermos> ListaContagiado = new List<Enfermos>();
        public static List<Enfermosinfo> Listainformacion = new List<Enfermosinfo>();
        public static ArbolAVL<Enfermosinfo> listaenfermos = new Estructuras.ArbolAVL<Enfermosinfo>();
        public List<Simulacion> simulacions = new List<Simulacion>();
        public static Estructuras.ArbolAVL<Enfermos> arbolpaciente = new Estructuras.ArbolAVL<Enfermos>();
        delegate void delenfermo(Enfermos enfermos);
        // GET: Enfermos
        public ActionResult Index()
        {
            //var Delenfermo = new delenfermo(arbolpaciente.Add());
            
            return View(Helpers.Storage.Instancia.ListaContagiado);
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
            //var list2 = new List<string>() { "Fraijanes", "Los esclavos", "Villa santorini" };
            //ViewBag.list2 = list2;
            ////if (ViewBag.list == "Capital")
            ////{
            ////    //Simulacion del examen 
            
            return View();
        }

        public ActionResult Graficos()
        {
            Highcharts ColumnChart = new Highcharts("ColumnChart");
            ColumnChart.InitChart(new DotNet.Highcharts.Options.Chart()   //inicializar el fondo dela grafica que sera de color "Almendras blanqueadas" 
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new DotNet.Highcharts.Helpers.BackColorOrGradient(System.Drawing.Color.BlanchedAlmond),
                Style = "fontWeight: 'Bold' , FontSize: '17ptx'",
                BorderColor = System.Drawing.Color.Azure,
                BorderRadius = 0,
                BorderWidth = 2,
            });
            ColumnChart.SetTitle(new DotNet.Highcharts.Options.Title()  //nombre de el titulo de la grafica 
            {
                Text = "Grafica de Casos"
            });
            ColumnChart.SetSubtitle(new DotNet.Highcharts.Options.Subtitle() // subtitulo y descripción de la gráfica 
            {
                Text = "Cantidad de contagiados y recuperados"
            });
            ColumnChart.SetXAxis(new DotNet.Highcharts.Options.XAxis()     //obtiene la información de los datos que irán en el eje de las x
            {
                Type = DotNet.Highcharts.Enums.AxisTypes.Category,
                Title = new DotNet.Highcharts.Options.XAxisTitle() { Text = "Casos", Style = "fontWeight : 'bold' , fontSize: '17ptx'" },
                Categories = new[] { "Ingreso de Contagiados", "Ingreso de Sospechosos", "Sospechosos positivos", "Egresados" }

            });
            ColumnChart.SetYAxis(new DotNet.Highcharts.Options.YAxis()  //obtiene la información de los datos que irán en el eje de las y
            {
                Title = new DotNet.Highcharts.Options.YAxisTitle()
                {
                    Text = "Cantidades",
                    Style = "fontWeight: 'bold', fontSize: '17ptx'"
                },
                ShowFirstLabel = true,  //muestra que los datos si se han tomado con validez 
                ShowLastLabel = true,
                Min = 0 //empieza desde el valor de 0
            });
            ColumnChart.SetLegend(new DotNet.Highcharts.Options.Legend
            {
                Enabled = true,
                BorderColor = System.Drawing.Color.Aquamarine,
                BorderRadius = 6,
                BackgroundColor = new DotNet.Highcharts.Helpers.BackColorOrGradient(System.Drawing.ColorTranslator.FromHtml("#ADE6D8")) //color verde analogo
            });
            ColumnChart.SetSeries(new DotNet.Highcharts.Options.Series[]
            {
                new DotNet.Highcharts.Options.Series
                {
                    Name = "Ingreso de Contagiados",
                    Data = new DotNet.Highcharts.Helpers.Data(new object[]{Storage.Instancia.CantidadContagiados}) //se puede acceder a lo que contiene la lista contagiados, pero se puede hacer una lista de contagiados etc
                },
                new DotNet.Highcharts.Options.Series()
                {
                    Name = "Ingreso de Sospechosos",
                    Data = new DotNet.Highcharts.Helpers.Data (new object[]{Storage.Instancia.CantidadSospechosos}) //se agrega la cantidad de recuperados que hay recordar que se puede referenciar los datos que ya se han obtenido
                },
                new DotNet.Highcharts.Options.Series()
                {
                    Name = "Sospechosos Positivos",
                    Data = new DotNet.Highcharts.Helpers.Data (new object[]{Storage.Instancia.CantidadContagiados}) //se agrega la cantidad de recuperados que hay recordar que se puede referenciar los datos que ya se han obtenido
                },
                new DotNet.Highcharts.Options.Series()
                {
                    Name = "Egresados (recuperados)",
                    Data = new DotNet.Highcharts.Helpers.Data (new object[]{Storage.Instancia.CantidadRecuperados}) //se agrega la cantidad de recuperados que hay recordar que se puede referenciar los datos que ya se han obtenido
                }
            });

            return View(ColumnChart);
        }
        
        // POST: Enfermos/Create
        [HttpPost]
        public ActionResult Create(Enfermos enfermos)
        {

            //Enfermos[] datosenfermo = ListaContagiado.ToArray();

            //ListaContagiado.Add(enfermos);//
            if (Storage.Instancia.InfoEnfermosNombre.ContainsKey(enfermos.Nombre))
            {
                return View();
            }
            arbolpaciente.Add(enfermos, arbolpaciente.Raiz, Enfermos.CompararPorNombre);
            enfermos.Estado = "Sospechoso";
            Storage.Instancia.InfoEnfermosNombre.Add(enfermos.Nombre, enfermos);
            Storage.Instancia.InfoEnfermosApellido.Add(enfermos.Apellido, enfermos);
            Storage.Instancia.InfoEnfermosDPI.Add(enfermos.Dpi, enfermos);
            Storage.Instancia.CantidadSospechosos++;
            return RedirectToAction("Create");
            //if (enfermos.Save())
            //{
            //}
            //else
            //{
            //    return View(enfermos);
            //}
        }

        [HttpPost]
        public ActionResult Simulacion(Simulacion sim, Enfermos enfermos)
        {
            int contador = 0; 
            bool Contagiado = false;
            bool Sospechoso = true;
            if (Sospechoso == true)
            {
                sim.obtenerinfo();
                sim.ObtenEdad();
                contador++;
            }
            else
            {
                sim.obtenerinfo();
                sim.ObtenEdad();
            }
            sim.Contagiado();
            return RedirectToAction("Create");
            //implementacion para la tabla hash 
            //Dictionary<string, string> diccionario = new Dictionary<string, string>();
            //diccionario.Add(enfermos.Nombre, enfermos.Sintoma); // uno sirve de clave y el otro de valor, cambiarlo por int para poder ingresar lel valor como la hora de ingreso para que sea mas facil su reconocimiento
        }

        [HttpPost]
        public ActionResult Simulation(FormCollection collection)
        {
            HashSet<Enfermosinfo> codigo = new HashSet<Enfermosinfo>();
            Enfermosinfo[] enfermost = Listainformacion.ToArray(); 
            try
            {
                var enfermosinfo = new Enfermosinfo()
                {
                    Edad = int.Parse(collection["Edad"]),
                    Departamento = collection["Departamento"],
                    Municipio = collection["Municipio"],
                    Hora = int.Parse(collection["Hora"]),
                    Fecha = int.Parse(collection["Fecha"]) 
                };
                Listainformacion.Add(enfermosinfo);
                //if (enfermosinfo.Save())
                //{
                //    NodoCola nvacola = new NodoCola()
                //    {
                //        Departamento = collection["Departamento"],
                //        Edad = int.Parse(collection["Edad"]), 
                //        Municipio = collection["Municipio"], 
                //        Hora = collection["Hora"], 
                //        Fecha = collection["Fecha"]
                //    };
                //    return RedirectToAction("Create");
                //}
                //else
                {
                    return View(enfermosinfo);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        // GET: Enfermos/Edit/5
        public ActionResult BusquedaPaciente(string nombre, string apellido, string DPI)
        {
           
           // enfermosinfo.Find(x => x.)
            if (String.IsNullOrEmpty(nombre) && String.IsNullOrEmpty(apellido) && String.IsNullOrEmpty(DPI))
            {
                if (Storage.Instancia.InfoEnfermosNombre.Count == 0)
                {
                    return RedirectToAction("Create");
                }
                return View(Storage.Instancia.InfoEnfermosNombre.Values.ToList());
            }
            else if (!String.IsNullOrEmpty(nombre))
            {
                //var paciente = arbolpaciente.Buscar(new Enfermos() { Nombre = nombre }, arbolpaciente.Raiz, Enfermos.CompararPorNombre);
                if (Storage.Instancia.InfoEnfermosNombre.ContainsKey(nombre))
                {
                    return View(Storage.Instancia.InfoEnfermosNombre.Values.Where(x => x.Nombre == nombre));
                }
            }
            else if (!String.IsNullOrEmpty(apellido))
            {
                //var paciente = arbolpaciente.Buscar(new Enfermos() { Apellido = apellido }, arbolpaciente.Raiz, Enfermos.CompararPorApellido
                if (Storage.Instancia.InfoEnfermosApellido.ContainsKey(apellido))
                {
                    return View(Storage.Instancia.InfoEnfermosApellido.Values.Where(x => x.Apellido == apellido));
                }
            }
            else
            {
                //var paciente = arbolpaciente.Buscar(new Enfermos() { Dpi = DPI }, arbolpaciente.Raiz, Enfermos.CompararPorDPI);
                if (Storage.Instancia.InfoEnfermosDPI.ContainsKey(DPI))
                {
                    var paciente = Storage.Instancia.InfoEnfermosDPI[DPI];
                    return View(Storage.Instancia.InfoEnfermosDPI.Values.Where(x=>x.Dpi == DPI));
                }
            }
            return View(Storage.Instancia.InfoEnfermosNombre.Values.ToList());
        }
        Enfermosinfo buscarenarbol(int indice)
        {
           
            foreach (var item in Listainformacion)
            {
                if (item.Nombre == Convert.ToString(indice)) 
                {
                     //arbolpaciente.CreaArbol(Listainformacion);
                    return item; 
                }
            }
            return new Enfermosinfo(0, "No existe entre los pacientes registrados", "", "", "", "", "");
           
            //return buscarenarbol(indice);
            //throw new NotImplementedException("Asegúrese de que hay pacientes");
        }

        public ActionResult CambiarAContagiado(string nombre)
        {
            if (Storage.Instancia.InfoEnfermosNombre[nombre].Estado == "Sospechoso")
            {
                Storage.Instancia.InfoEnfermosNombre[nombre].Estado = "Contagiado";
                Storage.Instancia.CantidadContagiados++;
            }
            else
            {
                Storage.Instancia.InfoEnfermosNombre[nombre].Estado = "Recuperado";
                Storage.Instancia.CantidadRecuperados++;
            }
            return RedirectToAction("BusquedaPaciente", new { nombre = nombre });
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Enfermos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
                return View(); 
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
