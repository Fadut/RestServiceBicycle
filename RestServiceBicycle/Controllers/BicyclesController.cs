using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;


namespace RestServiceBicycle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicyclesController : ControllerBase
    {

        private static readonly List<Bicycle> bicycles = new List<Bicycle>()
        {
            new Bicycle(1, "Red", 1500, 4),
            new Bicycle(2, "Black", 2000, 5),
            new Bicycle(3, "Grey", 2300, 6),
            new Bicycle(4, "Black", 1700, 4),
            new Bicycle(5, "Blue", 2200, 5),
            new Bicycle(6, "Silver", 2750, 8)
        };


        // GET: api/Bicycles
        [HttpGet]
        public IEnumerable<Bicycle> Get()
        {
            return bicycles;
        }

        // GET: api/Bicycles/5
        [HttpGet("{id}", Name = "Get")]
        public Bicycle Get(int id)
        {
            return bicycles.Find(i => i.Id == id);
        }

        // POST: api/Bicycles
        [HttpPost]
        public void Post([FromBody] Bicycle value)
        {
            bicycles.Add(value);
        }

        // PUT: api/Bicycles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bicycle value)
        {
            Bicycle bicycle = Get(id);
            if (bicycle != null)
            {
                bicycle.Id = value.Id;
                bicycle.Color = value.Color;
                bicycle.Gear = value.Gear;
                bicycle.Price = value.Price;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Bicycle bicycle = Get(id);
            bicycles.Remove(bicycle);
        }
    }
}
