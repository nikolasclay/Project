using CarDealership.Data;
using CarDealership.Data.Interface;
using CarDealership.Model;
using CarDealership.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDealership.UI.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class VehicleController : ApiController
    {
        ICarRepository _repo = CarFactory.Create();

        [Route("api/vehicle/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string quicksearch, decimal? minprice, decimal? maxprice, int? minyear, int? maxyear)
        {
            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    QuickSearch = quicksearch,
                    MinPrice = minprice,
                    MaxPrice = maxprice,
                    MinYear = minyear,
                    MaxYear = maxyear
                };

                return Ok(_repo.QuickSearch(parameters));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/vehicle/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchById(int id)
        {
            Vehicle toReturn = _repo.GetVehicleById(id);
            if(toReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(toReturn);
            }
        }
        [Route("api/vehicle/makes")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByMake()
        {
            List<VehicleMake> toReturn = _repo.GetAllMakes();
            if (toReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(toReturn);
            }
        }
        [Route("api/vehicle/models")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByModel()
        {
            List<VehicleModel> toReturn = _repo.GetAllModels();
            if (toReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(toReturn);
            }
        }
        [Route("api/vehicle/specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchSpecials()
        {
            List<Special> toReturn = _repo.GetAllSpecials();
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

