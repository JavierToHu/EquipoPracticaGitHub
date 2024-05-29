using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class TipoEvento
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }

        public List<ML.TipoEvento> TiposEventos { get; set; }
    }
}