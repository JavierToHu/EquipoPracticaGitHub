using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_PL.Controllers
{
    public class TipoEventoController : ApiController
    {

        [HttpGet]
        [Route("api/TipoEvento/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.TipoEvento.GetAllTipoEvento();

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }

            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }

        [HttpPost]
        [Route("api/TipoEvento/Add")]

        public IHttpActionResult Add([FromBody] ML.TipoEvento tipoEvento)
        {
            var result = BL.TipoEvento.Add(tipoEvento);

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
        [Route("api/TipoEvento/Update")]

        public IHttpActionResult Update([FromBody] ML.TipoEvento tipoEvento)
        {
            var result = BL.TipoEvento.Update(tipoEvento);

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
        [Route("api/TipoEvento/Delete")]

        public IHttpActionResult Delete(int IdTipoEvento)
        {
            var result = BL.TipoEvento.Delete(IdTipoEvento);

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
        [Route("api/TipoEvento/GetById")]

        public IHttpActionResult GetById(int IdTipoEvento)
        {
            var result = BL.TipoEvento.GetById(IdTipoEvento);

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }
    }
}
