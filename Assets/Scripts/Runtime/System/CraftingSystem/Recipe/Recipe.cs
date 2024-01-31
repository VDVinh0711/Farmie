
using System.Collections.Generic;
using UnityEngine;

public class Recipe 
{
    private List<CeatItemCraftSO> _listRecipe = new();
    public List<CeatItemCraftSO> ListRecipe => _listRecipe;

    public Recipe()
    {
        LoadRecipe();
    }

    private void LoadRecipe()
    {
        var recipes = Resources.LoadAll<CeatItemCraftSO>("Craft");
        foreach (var recipe in recipes)
        {
            _listRecipe.Add(recipe);
        }
    }

    
}
