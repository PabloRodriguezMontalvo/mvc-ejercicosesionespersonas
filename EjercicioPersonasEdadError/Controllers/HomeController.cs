using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjercicioPersonasEdadError.Models;

namespace EjercicioPersonasEdadError.Controllers
{
   [HandleError(View = "Error")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new Persona());
        }
        [HttpPost]
        public ActionResult Index(Persona model)
        {
            if(model.Edad<18 || model.Edad>65)
                throw new MiExcepcion("Edad incorrecta "+model.Edad);

            Session["persona"] = model;


            return RedirectToAction("Ver");
        }

        public ActionResult Ver()
        {
            return View(/*(Persona) Session["persona"]*/);
        }
    }
}