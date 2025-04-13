using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Liga_Pro.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Nombre el equipo")]

        public string Nombre { get; set; }
        [Range(0, 100)]
        public int partidosJugados { get; set; }
        [Range(0, 100)]

        public int partidosGanados { get; set; }
        [Range(0, 100)]

        public int partidosEmpatados { get; set; }
        [Range(0, 100)]
        public int partidosPerdidos { get; set; }

        public int Puntos => (partidosGanados * 3) + (partidosEmpatados * 1);

        //Manejamos el escudo de cada equipo.
        [DisplayName("Escudo del equipo")]
        public string Imagen { get; set; }
        public string Descripcion { get; set; }

    }
}
