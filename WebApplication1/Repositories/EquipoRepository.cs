using Liga_Pro.Models;

namespace Liga_Pro.Repositories
{
    public class EquipoRepository
    {
        public IEnumerable<Equipo> DevuelveListadoEquipos()
        {
            List<Equipo> equipos = new List<Equipo>();
            Equipo ldu = new Equipo
            {
                Id = 1,
                Nombre = "Liga de Quito",
                partidosJugados = 10,
                partidosGanados = 10,
                partidosEmpatados = 0,
                partidosPerdidos = 0
            };
            equipos.Add(ldu);

            Equipo idv = new Equipo
            {
                Id = 2,
                Nombre = "Independiente del Valle",
                partidosJugados = 10,
                partidosGanados = 5,
                partidosEmpatados = 1,
                partidosPerdidos = 3
            };
            equipos.Add(idv);

            return(equipos);

        }

    }
}
