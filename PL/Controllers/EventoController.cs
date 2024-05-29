using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EventoController : Controller
    {
        [HttpGet]
        public ActionResult GetAllEvento()
        {
            ML.Evento evento = new ML.Evento();
            evento.Eventos = new List<ML.Evento>();

            evento.TipoEvento = new ML.TipoEvento(); //DDLTipoEvento

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44326/");
                var responseTask = client.GetAsync("api/Evento/GetAll");

                responseTask.Wait();

                var resultTask = responseTask.Result;

                if (resultTask.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Content.ReadAsAsync<List<ML.Evento>>();
                    readTask.Wait();

                    evento.Eventos = readTask.Result;

                    return View(evento);
                }
                else
                {
                    return View(evento);
                }
            }
        }

        //[HttpGet]
        //public ActionResult FormsEvento(int? IdEvento)
        //{
        //    ML.Evento eventoForms = new ML.Evento();

        //    eventoForms.TipoEvento = new ML.TipoEvento();

        //    var resulteEvento = BL.TipoEvento.GetAllTipoEvento();
        //    List<ML.TipoEvento> EventoLista = resulteEvento.Item3;


        //    if (IdEvento != null) //UPDATE
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:44326/");
        //            var responseTask = client.GetAsync("api/Evento/GetById?IdEvento=" + IdEvento);

        //            responseTask.Wait();

        //            var resultTask = responseTask.Result;

        //            if (resultTask.IsSuccessStatusCode)
        //            {
        //                var readTask = resultTask.Content.ReadAsAsync<ML.Evento>(); 

        //                readTask.Wait();

        //                eventoForms = readTask.Result;

        //                eventoForms.TipoEvento.TiposEventos = EventoLista;

        //                return View(eventoForms);
        //            }
        //            else
        //            {
        //                return View(eventoForms);
        //            }
        //        }
        //    }
        //    else //ADD
        //    {
        //        eventoForms.TipoEvento.TiposEventos = EventoLista;
        //        return View(eventoForms);
        //    }
        //}

        [HttpGet]
        public ActionResult FormsEvento(int? IdEvento)
        {
            ML.Evento eventoForms = new ML.Evento();
            eventoForms.TipoEvento = new ML.TipoEvento();

            var resulteEvento = BL.TipoEvento.GetAllTipoEvento();
            List<ML.TipoEvento> EventoLista = resulteEvento.Item3;

            if (IdEvento != null) //UPDATE
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44326/");
                    var responseTask = client.GetAsync("api/Evento/GetById?IdEvento=" + IdEvento);
                    responseTask.Wait();
                    var resultTask = responseTask.Result;

                    if (resultTask.IsSuccessStatusCode)
                    {
                        var readTask = resultTask.Content.ReadAsAsync<ML.Evento>();
                        readTask.Wait();
                        eventoForms = readTask.Result;
                    }
                }
            }
            else //ADD
            {
                eventoForms.Fecha = DateTime.Now; // Inicializar con la fecha actual
            }

            eventoForms.TipoEvento.TiposEventos = EventoLista;
            return View(eventoForms);
        }


        [HttpPost]
        public ActionResult FormsEvento(ML.Evento evento)
        {

            if (ModelState.IsValid)
            {
                if (evento.IdEvento != 0) //Update
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44326/");
                        var responseTask = client.PutAsJsonAsync<ML.Evento>("api/Evento/Update", evento);

                        var resultTask = responseTask.Result;

                        if (resultTask.IsSuccessStatusCode)
                        {
                            ViewBag.Text = "Se actualizo exitosamente";
                        }
                        else
                        {
                            ViewBag.Text = "No se actualizo exitosamente";
                        }
                        return PartialView("Modal");
                    }
                }
                else //ADD
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44326/");
                        var responseTask = client.PostAsJsonAsync<ML.Evento>("api/Evento/Add", evento);

                        responseTask.Wait();

                        var resultTask = responseTask.Result;

                        if (resultTask.IsSuccessStatusCode)
                        {
                            ViewBag.Text = "Se agrego exitosamente";
                        }
                        else
                        {
                            ViewBag.Text = "No se agrego exitosamente";
                        }
                        return PartialView("Modal");
                    }
                }

            }

            return View(evento);
        }

        [HttpGet]
        public ActionResult DeleteEvento(int? IdEvento)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44326/");
                var responseTask = client.DeleteAsync("api/Evento/Delete?IdEvento=" + IdEvento);

                responseTask.Wait();

                var resultTask = responseTask.Result;

                if (resultTask.IsSuccessStatusCode)
                {
                    ViewBag.Text = "Se ha eliminado correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "No ha eliminado correctamente";
                    return PartialView("Modal");
                }
            }
        }
    }
}