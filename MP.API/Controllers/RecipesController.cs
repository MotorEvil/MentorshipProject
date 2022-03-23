namespace MP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipesDomain _recipes;

    public RecipesController(IRecipesDomain recipes)
    {
        _recipes = recipes;
    }

    // GET: api/<RecipesController>
    [HttpGet]
    public async Task<List<RecipeModel>> GetAllRecipes()
    {
        return await _recipes.GetAllRecipesDomain();
    }

    // GET api/<RecipesController>/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<RecipeModel>> GetRecipeById(string id)
    {
        var result = await _recipes.GetRecipeByIdDomain(id);

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

        var model = await _recipes.RecipePostAsyncDomain(recipe);

        return NoContent();

    }

    // PUT api/<RecipesController>/5
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> PutRecipe(string id, RecipeModel updateRecipe)
    {
        var recipe = await _recipes.GetRecipeByIdDomain(id);

        if (recipe is null)
        {
            return NotFound();
        }

        updateRecipe.Id = recipe.Id;

        await _recipes.UpdateRecipeDomainAsync(updateRecipe);

        return CreatedAtAction(nameof(GetRecipeById), new { id = updateRecipe.Id }, updateRecipe);
    }

    // DELETE api/<RecipesController>/5
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteRecipe(string id)
    {
        var recipe = await _recipes.GetRecipeByIdDomain(id);

        if (recipe is null)
        {
            return NotFound();
        }

        await _recipes.DeleleRecipeDomainAsync(id);

        return NoContent();
    }
}
