using Liga_Pro.Models;
using Liga_Pro.Data;
using System.Collections.Generic;
using System.Linq;

namespace Liga_Pro.Repositories
{
    public class EquipoRepository
    {
        /* Se realizo un cambio completo al repositorio
        ya que el anterior usaba la serializacion para guardar en .json
        ahora implementamos bases de datos.
        */
        private readonly ApplicationDbContext _context;

        public EquipoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipo> DevuelveListadoEquipos()
        {
            return _context.Equipos.ToList();
        }

        public Equipo DevuelveEquiposporId(int id)
        {
            return _context.Equipos.Find(id);
        }

        public void ActualizarEquipo(int id, Equipo equipo)
        {
            var existente = _context.Equipos.Find(id);
            if (existente != null)
            {
                existente.Nombre = equipo.Nombre;
                existente.partidosJugados = equipo.partidosJugados;
                existente.partidosGanados = equipo.partidosGanados;
                existente.partidosEmpatados = equipo.partidosEmpatados;
                existente.partidosPerdidos = equipo.partidosPerdidos;
                existente.Imagen = equipo.Imagen;
                existente.Descripcion = equipo.Descripcion;

                _context.SaveChanges();
            }
        }

        public void EliminarEquipo(int id)
        {
            var equipo = _context.Equipos.Find(id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
                _context.SaveChanges();
            }
        }

        public void CrearEquipo(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            _context.SaveChanges();
        }
    }
}


