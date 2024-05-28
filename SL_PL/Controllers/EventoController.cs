using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_PL.Controllers
{
    public class EventoController : ApiController
    {
        [HttpGet]
        [Route("api/Evento/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Evento.GetAll();

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result.Item3);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }

        [HttpPost]
        [Route("api/Evento/Add")]

        public IHttpActionResult Add([FromBody] ML.Evento evento)
        {
            var result = BL.Evento.Add(evento);

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }

        [HttpPut]
        [Route("api/Evento/Update")]

        public IHttpActionResult Update([FromBody] ML.Evento evento)
        {
            var result = BL.Evento.Update(evento);

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }


        [HttpDelete]
        [Route("api/Evento/Delete")]

        public IHttpActionResult Delete(int IdEvento)
        {
            var result = BL.Evento.Delete(IdEvento);

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }

        [HttpGet]
        [Route("api/Evento/GetById")]

        public IHttpActionResult GetById(int IdEvento)
        {
            var result = BL.Evento.GetById(IdEvento);

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result.Item3);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }
    }
}
