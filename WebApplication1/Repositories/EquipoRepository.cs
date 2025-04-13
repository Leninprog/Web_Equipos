using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Liga_Pro.Models;

namespace Liga_Pro.Repositories
{
    public class EquipoRepository
    {
        /* 
        Ruta del archivo Json, se guardan ahi los datos de los equipos 
        Se crea automanticamente una carpeta "Data" en la raiz del proyecto 
        Nos ayudamos de chatgpt para realizar y guiarnos en los cambios respecto al archivo de Json.
        El equipos.json se cambiaron propiedades:
        Accion de compilacion: Contenido
        Copiar en la direccion de salida: Copiar siempre.
         */
        private static string _archivoJson = Path.Combine(Directory.GetCurrentDirectory(), "Data", "equipos.json");
        
        // Lista estática que actúa como "base de datos en memoria"
        public static List<Equipo> Equipos;

        //Constructor que carga los equipos desde el archivo.
        public EquipoRepository()
        {
            if (Equipos == null || Equipos.Count == 0)
            {
                Equipos = CargarEquiposDesdeArchivo(); //Lee el archivo json
            }
        }

        //Carga los datos del archivo json si existen, sino devuelve una lista vacia
        private List<Equipo> CargarEquiposDesdeArchivo()
        {
            if (!File.Exists(_archivoJson))
            {
                return new List<Equipo>();
            }
            // lee el contenido del archivo json
            var json = File.ReadAllText(_archivoJson);
            // Convierte el texto de json a objetos Equipo C# (Deserializar)
            return JsonSerializer.Deserialize<List<Equipo>>(json) ?? new List<Equipo>();
        }

        /*
        Guardaremos los datos actuales al json.
        Llamar cada vez que se actualice los datos de los equipos. 
        */
        private void GuardarEquiposEnArchivo()
        {
            //Convierte objetos de C# a textos Json. (Serializar)
            var json = JsonSerializer.Serialize(Equipos);
            //Escribir el texto Json en el archivo
            File.WriteAllText(_archivoJson, json);
        }

        public IEnumerable<Equipo> DevuelveListadoEquipos()
        {
            return Equipos;
        }

        // Devuelve un equipo por su ID
        public Equipo DevuelveEquiposporId(int Id)
        {
            return Equipos.FirstOrDefault(item => item.Id == Id);
        }

        // Actualiza los datos del equipo guardando en archivo de Json
        public bool ActualizarEquipo(int Id, Equipo equipo)
        {
            var existente = Equipos.First(item => item.Id == Id);
            if (existente == null)
            {
                return false;
            }

            //Actualizar los valores del equipo
            existente.Nombre = equipo.Nombre;
            existente.partidosJugados = equipo.partidosJugados;
            existente.partidosGanados = equipo.partidosGanados;
            existente.partidosEmpatados = equipo.partidosEmpatados;
            existente.partidosPerdidos = equipo.partidosPerdidos;

            //Guardamos en json.
            GuardarEquiposEnArchivo();
            return true;
        }

        public bool EliminarEquipo(int Id)
        {
            var equipo = Equipos.FirstOrDefault(item => item.Id == Id);
            if (equipo != null)
            {
                Equipos.Remove(equipo);
                GuardarEquiposEnArchivo();
                return true;
            }
            return false;
        }

    }
}

