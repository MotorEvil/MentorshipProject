namespace MP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientsDomain _ingredients;

    public IngredientsController(IIngredientsDomain ingredients)
    {
        _ingredients = ingredients;
    }

    // GET: api/<MealsController>
    [HttpGet]
    public async Task<List<IngredientModel>> GetAllIngredients()
    {
        return await _ingredients.GetAllIngredientsDomain();
    }

    // GET api/<MealsController>/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<IngredientModel>> GetIngredientById(string id)
    {
        var result = await _ingredients.GetIngredientByIdDomain(id);

        if (result is null)
        {
            return NotFound();
        }

        return result;
    }

    // POST api/<MealsController>
    [HttpPost]
    public async Task<IActionResult> PostIngredients(IngredientModel meal)
    {
        var model = await _ingredients.PostIngredientAsyncDomain(meal);

        return NoContent();
    }

    // PUT api/<MealsController>/5
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> PutIngredient(string id, IngredientModel updateIngredient)
    {
        var recipe = await _ingredients.GetIngredientByIdDomain(id);

        if (recipe is null)
        {
            return NotFound();
        }

        updateIngredient.Id = recipe.Id;

        await _ingredients.UpdateIngredientAsyncDomain(updateIngredient);

        return CreatedAtAction(nameof(GetIngredientById), new { id = updateIngredient.Id }, updateIngredient);
    }

    // DELETE api/<MealsController>/5
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteIngredient(string id)
    {
        var recipe = await _ingredients.GetIngredientByIdDomain(id);

        if (recipe is null)
        {
            return NotFound();
        }

        await _ingredients.DeleteIngredientAsyncDomain(id);

        return NoContent();
    }
}
