using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LaboratorioCRUDAlumnos.Models;

namespace LaboratorioCRUDAlumnos.Controllers
{
    public class AlumnoController : Controller
    {
        private List<AlumnoModel> ObtenerAlumnos()
        {
            if (Session["alumnos"] == null)
            {
                List<AlumnoModel> alumnos = new List<AlumnoModel>();
                alumnos.Add(new AlumnoModel { Id = 1, Nombres = "Juan", Apellidos = "Pérez Gómez", Edad = 20, Correo = "juan.perez@tecsup.edu.pe" });
                alumnos.Add(new AlumnoModel { Id = 2, Nombres = "María", Apellidos = "López Torres", Edad = 22, Correo = "maria.lopez@tecsup.edu.pe" });
                alumnos.Add(new AlumnoModel { Id = 3, Nombres = "Carlos", Apellidos = "Ramírez Díaz", Edad = 19, Correo = "carlos.ramirez@tecsup.edu.pe" });
                Session["alumnos"] = alumnos;
            }

            return (List<AlumnoModel>)Session["alumnos"];
        }

        private AlumnoModel BuscarAlumno(int? id)
        {
            if (id == null) return null;
            return ObtenerAlumnos().FirstOrDefault(a => a.Id == id.Value);
        }

        public ActionResult Index()
        {
            return View(ObtenerAlumnos());
        }

        public ActionResult Details(int? id)
        {
            AlumnoModel alumno = BuscarAlumno(id);
            if (alumno == null) return HttpNotFound();

            return View(alumno);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlumnoModel model)
        {
            if (!ModelState.IsValid) return View(model);

            List<AlumnoModel> alumnos = ObtenerAlumnos();
            model.Id = alumnos.Count == 0 ? 1 : alumnos.Max(a => a.Id) + 1;
            alumnos.Add(model);

            TempData["Mensaje"] = "Alumno registrado correctamente.";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            AlumnoModel alumno = BuscarAlumno(id);
            if (alumno == null) return HttpNotFound();

            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlumnoModel model)
        {
            if (!ModelState.IsValid) return View(model);

            AlumnoModel alumno = BuscarAlumno(model.Id);
            if (alumno == null) return HttpNotFound();

            alumno.Nombres = model.Nombres;
            alumno.Apellidos = model.Apellidos;
            alumno.Edad = model.Edad;
            alumno.Correo = model.Correo;

            TempData["Mensaje"] = "Alumno actualizado correctamente.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            AlumnoModel alumno = BuscarAlumno(id);
            if (alumno == null) return HttpNotFound();

            return View(alumno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnoModel alumno = BuscarAlumno(id);
            if (alumno == null) return HttpNotFound();

            ObtenerAlumnos().Remove(alumno);

            TempData["Mensaje"] = "Alumno eliminado correctamente.";
            return RedirectToAction("Index");
        }
    }
}
