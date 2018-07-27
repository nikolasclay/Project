using Data;
using PriceConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PriceConfigurator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class AppController : ApiController
    {
        IAppRepo _repo = AppFactory.Create();

        [Route("api/app/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            List<App> toReturn = _repo.GetAll().ToList();
            if(toReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(toReturn);
            }
        }
        [Route("api/app/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            App toReturn = _repo.GetAppById(id);
            if (toReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(toReturn);
            }
        }
        [Route("api/app/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            App toReturn = _repo.GetAppByTitle(title);
            if (toReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(toReturn);
            }
        }

    }
}
