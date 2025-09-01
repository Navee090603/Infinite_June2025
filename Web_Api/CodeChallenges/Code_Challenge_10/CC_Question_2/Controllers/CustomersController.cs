using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using CC_Question_2.Models;

namespace CC_Question_2.Controllers
{
    public class CustomersController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: api/Customers/ByCountry
        [HttpGet]
        [Route("api/Customers/ByCountry/{country}")]
        [ResponseType(typeof(IEnumerable<Customer>))]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return BadRequest("Country parameter is required.");
            }

            var customers = db.Database.SqlQuery<Customer>("EXEC GetCustomersByCountry @p0", country).ToList();


            if (customers == null || customers.Count == 0)
            {
                return Ok(new List<Customer>());
            }

            return Ok(customers);
        }
    }
}
