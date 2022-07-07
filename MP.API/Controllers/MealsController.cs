namespace MP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealsController : ControllerBase
{
    private readonly IMeals _meals;

    public MealsController(IMeals meals)
    {
        _meals = meals;
    }

    // GET: api/<MealsController>
    [HttpGet]
    public async Task<List<MealModel>> GetAllMeals()
    {
        return await _meals.GetAllMeals();
    }

    // GET api/<MealsController>/5
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<MealModel>> GetMealById(string id)
    {
       var result = await _meals.GetMealById(id);

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
        var model = await _meals.PostMealAsync(meal);

        return NoContent();
    }

    // PUT api/<MealsController>/5
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> PutMeal(string id, MealModel updateMeal)
    {
        var recipe = await _meals.GetMealById(id);

        if (recipe is null)
        {
            return NotFound();
        }

        updateMeal.Id = recipe.Id;

        await _meals.UpdateMealAsync(updateMeal);

        return CreatedAtAction(nameof(GetMealById), new { id = updateMeal.Id }, updateMeal);
    }

    // DELETE api/<MealsController>/5
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteMeal(string id)
    {
        var recipe = await _meals.GetMealById(id);

        if (recipe is null)
        {
            return NotFound();
        }

        await _meals.DeleteMealAsync(id);

        return NoContent();
    }
}
