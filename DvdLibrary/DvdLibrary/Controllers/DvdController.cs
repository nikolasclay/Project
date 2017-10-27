using DvdLibrary.BLL;
using DvdLibrary.Data;
using DvdLibrary.Data.Mock;
using DvdLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        IDvdRepository _repo = DvdFactory.Create();

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdId(int id)
        {
            Dvd returned = _repo.GetDvdById(id);

            if (returned == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(returned);
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdTitle(string title)
        {
            List<Dvd> returned = _repo.GetDvdsByTitle(title);

            if (returned == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(returned);
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdYear(int releaseYear)
        {
            List<Dvd> returned = _repo.GetDvdsByReleaseYear(releaseYear);

            if (returned == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(returned);
            }
        }

        [Route("dvds/rating/{ratingType}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdRating(string ratingType)
        {
            List<Dvd> returned = _repo.GetDvdsbyRating(ratingType);

            if (returned == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(returned);
            }
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdEDirectorName(string directorName)
        {
            List<Dvd> returned = _repo.GetDvdsbyDirector(directorName);

            if (returned == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(returned);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            _repo.AddDvd(dvd);
            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            _repo.EditDvd(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _repo.DeleteDvd(id);
        }
    }
}
