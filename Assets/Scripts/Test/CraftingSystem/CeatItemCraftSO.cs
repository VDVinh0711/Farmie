using System;
using UnityEngine;
[CreateAssetMenu(menuName = "CreatNewScraft/ItemScraf")]
public class CeatItemCraftSO : ScriptableObject
{
    public string ID;
    public ItemObject itemCraf;
    public ItemObject item11;
    public ItemObject item22;
    public float TimeCreat;


    private void OnValidate()
    {
        ID = this.name;
    }

    public  static CeatItemCraftSO GetItemScraft(ItemObject item1, ItemObject item2)
    {
        if (item1 == null || item2 == null) return null;
        var ItenCraf = Resources.LoadAll<CeatItemCraftSO>("Craft");
        foreach (var item in ItenCraf)
        {
            if (item.item11.ID.Equals(item1.ID) && item.item22.ID.Equals(item2.ID) ||
                item.item11.ID.Equals(item2.ID) && item.item22.ID.Equals(item1.ID))
            {
                return item;
            }
        }

        return null;
    }
    
    
}
