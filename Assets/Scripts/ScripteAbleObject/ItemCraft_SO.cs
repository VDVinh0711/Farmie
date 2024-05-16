
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "CreatNewItemCraft/ItemCraf")]
public class ItemCraft_SO : ScriptableObject
{
    public string ID;
    public Item_SO itemCrafted;
    public List<IngredientItem> Ingredients;
    public string keyDes;
    public int timeCraf;
    public Sprite Sprite => itemCrafted.UIinGame;
    private void OnValidate()
    {
        ID = this.name;
    }

}


[Serializable]
public class IngredientItem
{
    public Item_SO ItemSo;
    public int quantity;
}
