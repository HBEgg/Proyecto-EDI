using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_EDI.Helpers;
using Proyecto_EDI.Models;
using Estructuras;
using DotNet.Highcharts; 
namespace Proyecto_EDI.Controllers
{
    public class EnfermosController : Controller
    {
        public static List<Enfermos> ListaContagiado = new List<Enfermos>();
        //public static ArbolAVL<Enfermos> listaenfermos = new Estructuras.ArbolAVL<Enfermos>
        public List<Simulacion> simulacions = new List<Simulacion>();
        public static Estructuras.ArbolAVL<Paciente> arbolpaciente = new Estructuras.ArbolAVL<Paciente>();
        //delegate void delenfermo(Enfermos enfermos,);
        // GET: Enfermos
        public ActionResult Index()
        {
            //var Delenfermo = new delenfermo(arbolpaciente.Add());
            
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
                    Data = new DotNet.Highcharts.Helpers.Data(new object[]{ListaContagiado}) //se puede acceder a lo que contiene la lista contagiados, pero se puede hacer una lista de contagiados etc
                },
                new DotNet.Highcharts.Options.Series()
                {
                    Name = "Ingreso de Sospechosos",
                    Data = new DotNet.Highcharts.Helpers.Data (new object[]{14,56,59,23,32,98,56,}) //se agrega la cantidad de recuperados que hay recordar que se puede referenciar los datos que ya se han obtenido
                },
                new DotNet.Highcharts.Options.Series()
                {
                    Name = "Sospechosos Positivos",
                    Data = new DotNet.Highcharts.Helpers.Data (new object[]{14,56,59,23,32,98,56}) //se agrega la cantidad de recuperados que hay recordar que se puede referenciar los datos que ya se han obtenido
                },
                new DotNet.Highcharts.Options.Series()
                {
                    Name = "Egresados (recuperados)",
                    Data = new DotNet.Highcharts.Helpers.Data (new object[]{14,56,59,23,32,98,56}) //se agrega la cantidad de recuperados que hay recordar que se puede referenciar los datos que ya se han obtenido
                }
            });

            return View(ColumnChart);
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
            int ViajeE = 0;
            int reusosp = 0;
            bool Contagiado = false;
            bool Sospechoso = true;
            if (Sospechoso == true)
            {
                sim.obtenerinfo();
                //if (enfermos.CContagio == "Viaje a Europa")
                //{
                //    ViajeE += 5;
                //}
                //if (enfermos.CContagio == "Reunión con sospechosos")
                //{
                //    reusosp += 10; 
                //}
                //enfermos.CContagio = " "+ enfermos.CContagio;
            }
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
        public ActionResult BusquedaPaciente(string nombre)
        {
            
            if (String.IsNullOrEmpty(nombre))
            {
                return View();
            }
            else
            {
                Enfermos encontrados = buscarenarbol(arbolpaciente.Buscar(nombre));
                return View(encontrados);
            }
        }

        
        Enfermos buscarenarbol(int indice)
        {
            
            foreach (var item in ListaContagiado)
            {
                if (item.id == indice)
                {
                    return item; 
                }
                return new Enfermos(0,"No existe entre los pacientes registrados", "", "", "", "", "");
            }
            throw new NotImplementedException();
        }

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
