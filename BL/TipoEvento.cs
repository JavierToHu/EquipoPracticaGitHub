using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoEvento
    {
        public (bool, string, List<ML.TipoEvento>, Exception) GetAllTipoEvento()
        {
            List<ML.TipoEvento> tipoEventos = new List<ML.TipoEvento>();

            try
            {
                using (DL.EjercicioGitHubEntities context = new DL.EjercicioGitHubEntities())
                {
                    var query = context.GetAllTipoEvento().ToList();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.TipoEvento tipoEventoObj = new ML.TipoEvento();  
                            tipoEventoObj.IdTipoEvento = item.IdTipoEvento;
                            tipoEventoObj.Nombre = item.Nombre;

                            tipoEventos.Add(tipoEventoObj);
                        }
                        return (true, null, tipoEventos, null);
                    }
                    else
                    {
                        return (false, null, tipoEventos, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }
    }
}