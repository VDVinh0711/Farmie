
using InventorySystem;
using UnityEngine;


public static class ItemHelper 
{


  
    
    public static void  SwapWithItemSlot(ItemSlot item, ItemSlot otherItem)
    {

        if (item.HasItem() && !otherItem.HasItem())
        {
            otherItem.AsignItem(item.Item);
            item.SetEmty();
        }
        else 
        if (!item.HasItem() && otherItem.HasItem())
        {
            item.AsignItem(otherItem.Item);
            otherItem.SetEmty();
        }
        else
        {
            var temp = item.Item;
            item.AsignItem(otherItem.Item);
            otherItem.AsignItem(temp);
        }
    }
        
        
}
