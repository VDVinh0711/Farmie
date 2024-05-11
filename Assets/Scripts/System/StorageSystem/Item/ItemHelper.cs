
using InventorySystem;
using UnityEngine;


public static class ItemHelper 
{


    public static Item MappingItem(Item_SO iteminfo, int quantity = 1)
    {
        switch (iteminfo)
        {
            case IStackAble stack:
                return new ItemStack(iteminfo, quantity);
                break;
            case AgriculturalSo dura:
                return new ItemDura(dura);
                break;
            case ClothesItem_SO clothes :
                return new ItemClothes(clothes);
                break;
            default:
                return new ItemDefaut(iteminfo);
            break;
        }
    }
    
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
