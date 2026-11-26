using KitchenLib.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartKitchenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly IGroceryService _groceryService;

        public GroceriesController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        // GET: api/<GroceriesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GroceriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GroceriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GroceriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GroceriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
