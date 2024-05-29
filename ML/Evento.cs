using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Evento
    {
        public int IdEvento { get; set; }

        [Required (ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public decimal Costo { get; set; } 

        public ML.TipoEvento TipoEvento { get; set; }

        public List<ML.Evento> Eventos { get; set; }
    }
}