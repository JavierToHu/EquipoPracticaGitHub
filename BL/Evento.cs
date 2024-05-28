
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Evento
	{
		public static (bool, string) Add(ML.Evento evento)
		{
			try
			{
				using (DL.EjercicioGitHubEntities context = new DL.EjercicioGitHubEntities())
				{
					int rowsAffected = context.AddEvento(evento.Nombre, evento.Ubicacion, evento.Fecha, evento.Costo, evento.TipoEvento.IdTipoEvento);

					if (rowsAffected > 0)
					{
						return (true, "Evento agregado correctamente");
					}
					else
					{
						return (false, "Error al agregar el evento");
					}
				}
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}

		public static (bool, string) Update(ML.Evento evento)
		{
			try
			{
				using (DL.EjercicioGitHubEntities context = new DL.EjercicioGitHubEntities())
				{
					int rowsAffected = context.UpdateEvento(evento.IdEvento, evento.Nombre, evento.Ubicacion, evento.Fecha, evento.Costo, evento.TipoEvento.IdTipoEvento);

					if (rowsAffected > 0)
					{
						return (true, "Evento actualizado correctamente");
					}
					else
					{
						return (false, "Error al actualizar el evento");
					}
				}
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}

		public static (bool, string) Delete(int IdEvento)
		{
			try
			{
				using (DL.EjercicioGitHubEntities context = new DL.EjercicioGitHubEntities())
				{
					int rowsAffected = context.DeleteEvento(IdEvento);

					if (rowsAffected > 0)
					{
						return (true, "Evento eliminado correctamente");
					}
					else
					{
						return (false, "Error al eliminar el evento");
					}
				}
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}

		public static (bool, string, List<ML.Evento>) GetAll()
		{
			ML.Evento evento = new ML.Evento();
			try
			{
				using (DL.EjercicioGitHubEntities context = new DL.EjercicioGitHubEntities())
				{
					var eventos = context.GetAllEvento().ToList();

					if (eventos != null)
					{
						evento.Eventos = new List<ML.Evento>();

						foreach (var eventoDB in eventos)
						{
							ML.Evento eventoObj = new ML.Evento();

							eventoObj.IdEvento = eventoDB.IdEvento;
							eventoObj.Nombre = eventoDB.Nombre;
							eventoObj.Ubicacion = eventoDB.Ubicacion;
							eventoObj.Fecha = eventoDB.Fecha;
							eventoObj.Costo = Convert.ToDecimal(eventoDB.Costo);

							eventoObj.TipoEvento = new ML.TipoEvento();
							eventoObj.TipoEvento.IdTipoEvento = Convert.ToInt32(eventoDB.IdTipoEvento);
							eventoObj.TipoEvento.Nombre = eventoDB.NombreEvento;

							evento.Eventos.Add(eventoObj);
                        }

						return (true, null, evento.Eventos);
                    }
                    else
                    {
						return (false, "Error al recuperar los registros", null);
                    }
                }
			}
			catch (Exception ex)
			{
				return (false, ex.Message, null);
			}
		}

		public static (bool, string, ML.Evento) GetById(int IdEvento)
		{
			ML.Evento evento = new ML.Evento();

			try
			{
				using (DL.EjercicioGitHubEntities context = new DL.EjercicioGitHubEntities())
				{
					var eventoDB = context.GetByIdEvento(IdEvento).SingleOrDefault();
					
					if (eventoDB != null)
					{
                        evento.IdEvento = eventoDB.IdEvento;
                        evento.Nombre = eventoDB.Nombre;
                        evento.Ubicacion = eventoDB.Ubicacion;
                        evento.Fecha = eventoDB.Fecha;
                        evento.Costo = Convert.ToDecimal(eventoDB.Costo);

                        evento.TipoEvento = new ML.TipoEvento();
                        evento.TipoEvento.IdTipoEvento = Convert.ToInt32(eventoDB.IdTipoEvento);
						evento.TipoEvento.Nombre = eventoDB.NombreEvento;

                        return (true, null, evento);
                    }
					else
					{
						return (false, "Error al recuperar el registro", null);
					}
                }
			}
			catch (Exception ex)
			{
				return (false, ex.Message, null);
			}
			return (false, null, null);
		}
    }
}
