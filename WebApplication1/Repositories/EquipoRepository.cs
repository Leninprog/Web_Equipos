using System.Collections.Generic;
using System.Linq;
using Liga_Pro.Models;

namespace Liga_Pro.Repositories
{
    public class EquipoRepository
    {
        // Lista estática que actúa como "base de datos en memoria"
        public static List<Equipo> Equipos = new List<Equipo>();

        public EquipoRepository()
        {
            // Solo inicializa una vez si la lista está vacía
            if (Equipos.Count == 0)
            {
                Equipos.Add(new Equipo
                {
                    Id = 1,
                    Nombre = "Liga de Quito",
                    partidosJugados = 10,
                    partidosGanados = 10,
                    partidosEmpatados = 0,
                    partidosPerdidos = 0
                });

                Equipos.Add(new Equipo
                {
                    Id = 2,
                    Nombre = "Independiente del Valle",
                    partidosJugados = 10,
                    partidosGanados = 5,
                    partidosEmpatados = 1,
                    partidosPerdidos = 3
                });
            }
        }

        // Devuelve la lista actual de equipos (sin reinicializar)
        public IEnumerable<Equipo> DevuelveListadoEquipos()
        {
            return Equipos;
        }

        // Devuelve un equipo por su ID
        public Equipo DevuelveEquiposporId(int Id)
        {
            return Equipos.FirstOrDefault(item => item.Id == Id);
        }

        // Actualiza los datos del equipo encontrado por ID
        public bool ActualizarEquipo(int Id, Equipo equipo)
        {
            var equipoExistente = Equipos.FirstOrDefault(item => item.Id == Id);
            if (equipoExistente == null)
            {
                return false;
            }

            equipoExistente.Nombre = equipo.Nombre;
            equipoExistente.partidosJugados = equipo.partidosJugados;
            equipoExistente.partidosGanados = equipo.partidosGanados;
            equipoExistente.partidosEmpatados = equipo.partidosEmpatados;
            equipoExistente.partidosPerdidos = equipo.partidosPerdidos;

            return true;
        }
    }
}

