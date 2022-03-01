namespace MP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipes;
    private readonly IIngredientService _ingrediens;
    public RecipesController(IRecipeService recipes,
                             IIngredientService ingrediens)
    {
        _recipes = recipes;
        _ingrediens = ingrediens;
    }

    // GET: api/<RecipesController>
    [HttpGet]
    public async Task<List<RecipeModel>> Get()
    {
        return await _recipes.GetRecipeAsync();
    }

    // GET api/<RecipesController>/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<RecipeModel>> Get(string id)
    {
        var result = await _recipes.FindRecipeById(id);

        if (result is null)
        {
            return NotFound();
        }

        return result;
    }

    // POST api/<RecipesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync(RecipeModel recipe)
    {

        List<IngredientModel> ingredientList = new List<IngredientModel>();

        foreach (var item in recipe.Ingredients)
        {

            var ingredient = _ingrediens.FindIngredientByName(item.Name);

            if (ingredient == "False")
            {
                await _ingrediens.CreateIngredient(item);

                ingredientList.Add(new IngredientModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CaloriesPer100 = item.CaloriesPer100
                });

            }
            else
            {
                IngredientModel ingModel = await _ingrediens.FindIngredientById(ingredient);

                ingredientList.Add(new IngredientModel
                {
                    Id = ingModel.Id,
                    Name = ingModel.Name,
                    CaloriesPer100 = ingModel.CaloriesPer100
                });

            }
        }

        RecipeModel model = new()
        {
            Name = recipe.Name,
            Description = recipe.Description,
            Ingredients = ingredientList
        };

        await _recipes.Createrecipe(model);

        return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
    }

    // PUT api/<RecipesController>/5
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, RecipeModel updateRecipe)
    {
        var recipe = await _recipes.FindRecipeById(id);

        if (recipe is null)
        {
            return NotFound();
        }

        updateRecipe.Id = recipe.Id;

        await _recipes.UpdateRecipe(updateRecipe);

        return CreatedAtAction(nameof(Get), new { id = updateRecipe.Id }, updateRecipe);
    }

    // DELETE api/<RecipesController>/5
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var recipe = await _recipes.FindRecipeById(id);

        if (recipe is null)
        {
            return NotFound();
        }

        await _recipes.DeleteRecipe(id);

        return NoContent();
    }
}
