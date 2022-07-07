namespace MP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipes _recipes;

    public RecipesController(IRecipes recipes)
    {
        _recipes = recipes;
    }

    // GET: api/<RecipesController>
    [HttpGet]
    public async Task<List<RecipeModel>> GetAllRecipes()
    {
        return await _recipes.GetAllRecipes();
    }

    // GET api/<RecipesController>/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<RecipeModel>> GetRecipeById(string id)
    {
        var result = await _recipes.GetRecipeById(id);

        if (result is null)
        {
            return NotFound();
        }

        return result;
    }

    // POST api/<RecipesController>
    [HttpPost]
    public async Task<IActionResult> PostRecipe(RecipeModel recipe)
    {

        var model = await _recipes.RecipePostAsync(recipe);

        return NoContent();

    }

    // PUT api/<RecipesController>/5
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> PutRecipe(string id, RecipeModel updateRecipe)
    {
        var recipe = await _recipes.GetRecipeById(id);

        if (recipe is null)
        {
            return NotFound();
        }

        updateRecipe.Id = recipe.Id;

        await _recipes.UpdateRecipeAsync(updateRecipe);

        return CreatedAtAction(nameof(GetRecipeById), new { id = updateRecipe.Id }, updateRecipe);
    }

    // DELETE api/<RecipesController>/5
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteRecipe(string id)
    {
        var recipe = await _recipes.GetRecipeById(id);

        if (recipe is null)
        {
            return NotFound();
        }

        await _recipes.DeleleRecipeAsync(id);

        return NoContent();
    }
}
