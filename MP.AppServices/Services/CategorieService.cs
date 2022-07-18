namespace MP.AppServices.Services;

public class CategorieService
{
    private readonly IMongoCollection<CategorieModel> _categories;

    public CategorieService(IAppDbConnection db)
    {
        _categories = db.CategorieCollection;
    }

    public Task CreateCategorie(CategorieModel categorie)
    {
        return _categories.InsertOneAsync(categorie);
    }

    public async Task<List<CategorieModel>> GetAllCategoriesAsync()
    {
        var result = await _categories.FindAsync(_ => true);
        return result.ToList();
    }

    public async Task<List<CategorieModel>> GetCategoriesByParentIdAsync(string parentId)
    {
        var result = await _categories.FindAsync(x => x.ParentId == parentId);
        return result.ToList();
    }

    public Task UpdateCategorie(CategorieModel categorie)
    {
        var filter = Builders<CategorieModel>.Filter.Eq("Id", categorie.Id);
        return _categories.ReplaceOneAsync(filter, categorie, new ReplaceOptions { IsUpsert = true });
    }

    public Task DeleteCategorie(string id)
    {
        return _categories.DeleteOneAsync(x => x.Id == id);
    }
}
