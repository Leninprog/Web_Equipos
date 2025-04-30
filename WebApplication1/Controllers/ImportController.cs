using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Liga_Pro.Models;
using Liga_Pro.Data;

namespace Liga_Pro.Controllers
{
    public class ImportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ImportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ImportarEquipos() 
        { 
            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "Data", "equipos.json");
            
            if (!System.IO.File.Exists(ruta))
            {
                return Content("El archivo equipos.json no existe en la ruta: " + ruta);
            }

            string json = System.IO.File.ReadAllText(ruta);
            var equipos = JsonConvert.DeserializeObject<List<Equipo>>(json);

            foreach (var equipo in equipos) 
            {
                bool existe = _context.Equipos.Any(e => e.Nombre == equipo.Nombre);

                if (!existe)
                {
                    //Borramos o limpiamos el ID que tenia el equipo para que SQL lo asigne automaticamente.
                    equipo.Id = 0;
                    _context.Equipos.Add(equipo);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("List", "Equipo");
        }
    }
}
