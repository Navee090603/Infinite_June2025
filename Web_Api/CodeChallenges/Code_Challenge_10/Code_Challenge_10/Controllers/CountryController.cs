using Code_Challenge_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Code_Challenge_10.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        // Like DataBase
        static List<Country> countries = new List<Country>()
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "United States", Capital = "Washington" },
            new Country { ID = 3, CountryName = "Australia", Capital = "Sydney" },
            new Country { ID = 4,CountryName="Russia",Capital="Moscow"}
        };

        // GET api/Country/All
        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> GetAll()
        {
            return countries;
        }

        // GET api/Country/ById
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetById(int id)
        {
            var item = countries.FirstOrDefault(c => c.ID == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST api/Country/Add  
        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage AddCountry([FromBody] Country country)
        {
            if (country == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured");

            if (countries.Any(c => c.ID == country.ID))
                return Request.CreateResponse(HttpStatusCode.Conflict, "Country with this ID exists.");

            countries.Add(country);
            return Request.CreateResponse(HttpStatusCode.Created, country);
        }

        // PUT api/Country/Update 
        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage UpdateCountry([FromBody] Country country)
        {
            if (country == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Occured");

            var existing = countries.FirstOrDefault(c => c.ID == country.ID);
            if (existing == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Country not found.");

            existing.CountryName = country.CountryName;
            existing.Capital = country.Capital;

            return Request.CreateResponse(HttpStatusCode.OK, existing);
        }

        // DELETE api/Country/Delete
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage DeleteCountry(int id)
        {
            var existing = countries.FirstOrDefault(c => c.ID == id);
            if (existing == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Country not found.");

            countries.Remove(existing);
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }
    }
}
