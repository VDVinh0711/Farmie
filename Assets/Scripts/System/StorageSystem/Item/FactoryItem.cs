
using System;
using InventorySystem;
public static class FactoryItem 
{
    public static Item CreateItem(Item item)
    {
        switch ( item)
        {
            case ItemStack itemStack :
                return new ItemStack(itemStack.ItemInfor, itemStack.NumberItem);
                break;
            case ItemDura itemdura:
               return new ItemDura(itemdura.ItemInfor, itemdura.CurDurability);
                break;
            case ItemClothes itemclothes :
              return new ItemClothes(itemclothes.ItemInfor as ClothesItem_SO);
                break;
            default:
               return new ItemDefaut(item.ItemInfor);
                break;
        }
    }


    public static Item CreateItem(Item_SO iteminfo, int quantity = 1)
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
    
    public static Item CreateItem(Item_SO item , int quanity , out int  requantity)
    {
        requantity = 0;
        Item _item = null;
        switch ( item)
        {
            case IStackAble stack :
                if (quanity > stack.MaxStack)
                {
                    _item = new ItemStack(item, stack.MaxStack);
                    requantity = quanity - stack.MaxStack;
                }
                else
                {
                    _item = new ItemStack(item,quanity);
                }
                break;
            case AgriculturalSo agriculturalSo:
                _item = new ItemDura(agriculturalSo);
                requantity = quanity - 1;
                break;
            case ClothesItem_SO clothesItemSo :
                _item = new ItemClothes(clothesItemSo);
                requantity = quanity - 1;
                break;
            
            default:
                _item = new ItemDefaut(item);
                requantity = quanity - 1;
                break;
        }

        return _item;
    }


    public static Item GetItem(Item item , Action setEmty , Action onChange,int quantity = 1 )
    {
        Item result = null;
        switch (item)
        {
            case ItemStack itemSlotStack:
                 result = (itemSlotStack.GetItemSlotStack(quantity));
                if(!itemSlotStack.HasItem()) setEmty();
                break;
            case ItemDura itemdura:
                 result = itemdura.GetItemSlotDure();
                if(!itemdura.HasItem()) setEmty();
                break;
            case ItemClothes itemclothes:
                 result = itemclothes.ItemClone();
                item.SetEmty();
                 break;
            default:
                 result =  item.ItemClone();
                item.SetEmty();
                break;
        }
        onChange();
        return result;

    }
}
