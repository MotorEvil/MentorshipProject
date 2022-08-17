using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MP.API.Controllers;
using MP.AppServices.Services;
using MP.Data.Models;
using MP.Domain.Base;
using MP.Domain.Interfaces;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MP.Tests.Tests;

public class IngredientsTest
{
    private readonly IngredientsController _ingredients;
    private readonly IIngredients _ingredientService = Substitute.For<IIngredients>();

    public IngredientsTest()
    {
        _ingredients = new IngredientsController(_ingredientService);
    }

    [Fact]
    public async Task GetIngredientById_ShouldReturnIngredient_WhenIngredientExists()
    {
        // Arrange

        var ingredientModel = new IngredientModel
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Ingredientas",
            CaloriesPer100 = 100
        };

        _ingredientService.GetIngredientById(ingredientModel.Id).Returns(ingredientModel);

        // Act

        var ingredient = await _ingredients.GetIngredientById(ingredientModel.Id);
        
        // Assert
        Assert.Equal(ingredientModel, ingredient.Value);

    }

    [Fact]
    public async Task GetIngredientById_ShouldReturnNotFound()
    {
        // Arrange
        _ingredientService.GetIngredientById(Arg.Any<string>()).ReturnsNull();

        // Act
        var ingredient = await _ingredients.GetIngredientById(Arg.Any<string>());

        // Assert
        Assert.Null(ingredient.Value);
    }

    [Fact]
    public async Task PostIngredientAsync_ShouldPostIngredient()
    {
        // Arrange

        var ingredientModel = new IngredientModel
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Ingredientas",
            CaloriesPer100 = 100
        };

        await _ingredientService.PostIngredientAsync(ingredientModel);

        // Act

        var ingredient = await _ingredients.PostIngredients(ingredientModel);

        // Assert
        Assert.Equal(ingredientModel, ingredient.Value);
    }

    [Fact]
    public async Task GetAllIngredients_ShouldReturnAllIngredients()
    {
        // Arrange
        List<IngredientModel> ingredientList = new List<IngredientModel>
        {
            new IngredientModel() {
                Id = Guid.NewGuid().ToString(),
                Name = "Ingredientas",
                CaloriesPer100 = 101},

             new IngredientModel() {
                Id = Guid.NewGuid().ToString(),
                Name = "Ingredientas2",
                CaloriesPer100 = 102},

            new IngredientModel() {
                Id = Guid.NewGuid().ToString(),
                Name = "Ingredientas3",
                CaloriesPer100 = 103}
        };

        _ingredientService.GetAllIngredients().Returns(ingredientList);

        // Act
        var result = await _ingredients.GetAllIngredients();

        // Assert
        var items = Assert.IsType<List<IngredientModel>>(result);
        Assert.Equal(3, items.Count);
    }

    [Fact]
    public async Task DeleteIngredient_ShouldDeleteIngredient()
    {
        // Arrange
        string deleteId = "123";
        var ingredientModel = new IngredientModel
        {
            Id = "123",
            Name = "Ingredientas",
            CaloriesPer100 = 100
        };
        
        _ingredientService.GetIngredientById(deleteId).Returns(ingredientModel);
        _ingredientService.DeleteIngredientAsync(deleteId).Returns(Task.CompletedTask);

        // Act
        var result = _ingredients.DeleteIngredient(deleteId);

        // Assert
        Assert.True(result.IsCompleted); 
    }

    [Fact]
    public async Task DeleteIngredient_ShouldReturnNotFound()
    {
        // Arrange
        string deleteId = "123";
        _ingredientService.GetIngredientById(deleteId).ReturnsNull();

        // Act
        var result = _ingredients.DeleteIngredient(deleteId);

        // Assert
        Assert.True(result.IsCompleted);
    }

    [Fact]
    public async Task PutIngredient_ShouldPutIngredient()
    {
        // Arrange

        var ingredientModel = new IngredientModel
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Ingredientas",
            CaloriesPer100 = 100
        };

        await _ingredientService.UpdateIngredientAsync(ingredientModel);

        // Act

        var ingredient = await _ingredients.PutIngredient(ingredientModel.Id, ingredientModel);

        // Assert
        Assert.NotNull(ingredient);
        
    }
}