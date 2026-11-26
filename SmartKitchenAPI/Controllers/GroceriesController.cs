using KitchenLib.Interfaces;
using KitchenLib.Models;
using Microsoft.AspNetCore.Mvc;
using SmartKitchenAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartKitchenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly IGroceryService _groceryService;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public GroceriesController(IGroceryService groceryService, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _groceryService = groceryService;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        // GET: api/<GroceriesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Grocery>> Get()
        {
            var groceries = _groceryService.GetAllAsync().Result.ToList();
            if (groceries.Count == 0)
            {
                return NotFound();
            }
            return Ok(groceries);
        }

        // GET api/<GroceriesController>/5
        [HttpGet("{id}")]
        public ActionResult<Grocery> Get(int id)
        {
            var grocery = _groceryService.GetByIdAsync(id).Result;
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
        }

        // POST api/<GroceriesController/scan>
        [HttpPost("scan")]
        public ActionResult<Grocery> Post([FromBody] ScanRequestDTO scanRequestDto)
        {
            var grocery = _groceryService.ProcessScanAsync(scanRequestDto.Barcode, scanRequestDto.Mode).Result;
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
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
