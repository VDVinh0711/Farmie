
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/IemIndex")]
public class ItemIndex : ScriptableObject
{
     public List<ItemObject> items;   
    
    public ItemObject GetItemFromString(string name)
    {
        return items.Find(X => X.name == name);
    }
}
