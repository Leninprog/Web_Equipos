using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Liga_Pro.Models;
using Liga_Pro.Repositories;

namespace Liga_Pro.Controllers
{
    public class EquipoController : Controller
    {

        public ActionResult View()
        {
            return View();
        }

        public ActionResult List()
        {
            EquipoRepository equipoRepository = new EquipoRepository();
            var equipos = equipoRepository.DevuelveListadoEquipos();
            
            equipos = equipos.OrderByDescending(item => item.partidosGanados);
            //equipos = equipos.Where(item => item.Nombre == "Liga de Quito");

            return View(equipos);
        }

    }
}
