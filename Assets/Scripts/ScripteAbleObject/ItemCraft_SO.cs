
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreatNewScraft/ItemScraf")]
public class ItemCraft_SO : ScriptableObject
{
    public string ID;
    public Item_SO itemCrafted;
    public List<MaterialItem> Materials;
    public string Description;
    public int timeCraf;
    public Sprite Sprite => itemCrafted.UIinGame;
    private void OnValidate()
    {
        ID = this.name;
    }

}


[Serializable]
public class MaterialItem
{
    public Item_SO ItemSo;
    public int quantity;
}
