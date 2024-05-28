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
                return Content(HttpStatusCode.OK, result.Item3);
            }

            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }
    }
}