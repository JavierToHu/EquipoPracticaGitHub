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
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TuFecha { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Costo { get; set; }

        public ML.TipoEvento TipoEvento { get; set; }

        public List<ML.Evento> Eventos { get; set; }
    }
}