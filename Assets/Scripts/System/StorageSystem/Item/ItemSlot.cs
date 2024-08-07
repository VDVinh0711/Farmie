using System;
using InventorySystem;
[Serializable]
public class ItemSlot
{
    private Item _item;
    private bool _isActive;
    public Item Item => _item;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            OnChangeActionItem();
        }
    }
    public Action<ItemSlot> ActionChangeItem;
    
    public ItemSlot() {}
    public ItemSlot(Item item)
    {
        _item = item;
    }
    public void AsignItem(Item item )
    {
      
        if(item == null) return;
        /*switch ( item)
        {
            case ItemStack itemStack :
                _item = new ItemStack(itemStack.ItemInfor, itemStack.NumberItem);
                break;
            case ItemDura itemdura:
                _item = new ItemDura(itemdura.ItemInfor, itemdura.CurDurability);
                break;
            case ItemClothes itemclothes :
                _item = new ItemClothes(itemclothes.ItemInfor as ClothesItem_SO);
                break;
           default:
                _item = new ItemDefaut(item.ItemInfor);
               break;
                
        }*/
        _item = FactoryItem.CreateItem(item);
        OnChangeActionItem();
    }
    public void AsignItem(Item_SO item , int quanity , out int  requantity)
    {
        requantity = 0;
        if(item == null) return;
        // switch ( item)
        // {
        //     case IStackAble stack :
        //         if (quanity > stack.MaxStack)
        //         {
        //             _item = new ItemStack(item, stack.MaxStack);
        //             requantity = quanity - stack.MaxStack;
        //         }
        //         else
        //         {
        //             _item = new ItemStack(item,quanity);
        //         }
        //         break;
        //     case AgriculturalSo agriculturalSo:
        //         _item = new ItemDura(agriculturalSo);
        //         requantity = quanity - 1;
        //         break;
        //     case ClothesItem_SO clothesItemSo :
        //         _item = new ItemClothes(clothesItemSo);
        //         requantity = quanity - 1;
        //         break;
        //     
        //     default:
        //         _item = new ItemDefaut(item);
        //         requantity = quanity - 1;
        //         break;
        // }
        _item = FactoryItem.CreateItem(item, quanity, out requantity);
        OnChangeActionItem();
    }
    public Item GetItemInventory( int quantity = 1 )
    {
      return FactoryItem.GetItem(_item, SetEmty, OnChangeActionItem,quantity);
    }

    public void UseItem()
    {
        _item.UseItem();
        if(!_item.HasItem()) SetEmty();
        OnChangeActionItem();
    }
    public void SetEmty()
    {
        _item = null;
        OnChangeActionItem();
    }
    private void OnChangeActionItem()
    {
        ActionChangeItem?.Invoke(this);
    }

    public bool HasItem()
    {
        return _item != null && _item.HasItem();
    }
}
