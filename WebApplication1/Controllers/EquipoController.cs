using Microsoft.AspNetCore.Mvc;
using Liga_Pro.Models;
using Liga_Pro.Repositories;
using Liga_Pro.Data;

namespace Liga_Pro.Controllers
{
    public class EquipoController : Controller
    {
        private readonly EquipoRepository _repository;

        public EquipoController(ApplicationDbContext context)
        {
            _repository = new EquipoRepository(context);
        }

        public ActionResult View()
        {
            return View();
        }

        public ActionResult List()
        {
            var equipos = _repository.DevuelveListadoEquipos();
            
            equipos = equipos.OrderByDescending(item => item.partidosGanados);
            //equipos = equipos.Where(item => item.Nombre == "Liga de Quito");

            return View(equipos);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int Id) {
            var equipo = _repository.DevuelveEquiposporId(Id);
            return View(equipo);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Equipo equipo)
        {
            try
            {
                _repository.ActualizarEquipo(Id, equipo);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int Id)
        {
            var equipo = _repository.DevuelveEquiposporId(Id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        public ActionResult Delete(int Id)
        {
            var equipo = _repository.DevuelveEquiposporId(Id);
            return View(equipo);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            _repository.EliminarEquipo(Id);
            return RedirectToAction(nameof(List));
        }

    }
}