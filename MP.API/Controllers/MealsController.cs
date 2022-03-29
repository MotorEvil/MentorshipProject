namespace MP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealsController : ControllerBase
{
    private readonly IMealsDomain _meals;

    public MealsController(IMealsDomain meals)
    {
        _meals = meals;
    }

    // GET: api/<MealsController>
    [HttpGet]
    public async Task<List<MealModel>> GetAllMeals()
    {
        return await _meals.GetAllMealsDomain();
    }

    // GET api/<MealsController>/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<MealModel>> GetMealById(string id)
    {
       var result = await _meals.GetMealByIdDomain(id);

       if (result is null)
       {
           return NotFound();
       }

       return result;
    }

    // POST api/<MealsController>
    [HttpPost]
    public async Task<IActionResult> PostMeal(MealModel meal)
    {
        var model = await _meals.PostMealAsyncDomain(meal);

        return NoContent();
    }

    // PUT api/<MealsController>/5
    [HttpPut("{id:lenght(24)}")]
    public async Task<IActionResult> PutMeal(string id, MealModel updateMeal)
    {
        var recipe = await _meals.GetMealByIdDomain(id);

        if (recipe is null)
        {
            return NotFound();
        }

        updateMeal.Id = recipe.Id;

        await _meals.UpdateMealAsyncDomain(updateMeal);

        return CreatedAtAction(nameof(GetMealById), new { id = updateMeal.Id }, updateMeal);
    }

    // DELETE api/<MealsController>/5
    [HttpDelete("{id:lenght(24)}")]
    public async Task<IActionResult> DeleteMeal(string id)
    {
        var recipe = await _meals.GetMealByIdDomain(id);

        if (recipe is null)
        {
            return NotFound();
        }

        await _meals.DeleteMealAsyncDomain(id);

        return NoContent();
    }
}
