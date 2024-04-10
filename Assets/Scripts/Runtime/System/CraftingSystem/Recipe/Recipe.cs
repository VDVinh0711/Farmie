
using System.Collections.Generic;
using UnityEngine;

public class Recipe 
{
    private List<ItemCraft_SO> _listRecipe = new();
    public List<ItemCraft_SO> ListRecipe => _listRecipe;

    public Recipe()
    {
        LoadRecipe();
    }

    private void LoadRecipe()
    {
        var recipes = Resources.LoadAll<ItemCraft_SO>("Craft");
        foreach (var recipe in recipes)
        {
            _listRecipe.Add(recipe);
        }
    }

    
}
