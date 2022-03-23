namespace MP.Domain.Recipes;

public interface IRecipesDomain
{
    Task<List<RecipeModel>> GetAllRecipesDomain();
    Task<RecipeModel> GetRecipeByIdDomain(string id);
    Task<RecipeModel> RecipePostAsyncDomain(RecipeModel recipe);
    Task UpdateRecipeDomainAsync(RecipeModel recipe);
    Task DeleleRecipeDomainAsync(string id);
}
