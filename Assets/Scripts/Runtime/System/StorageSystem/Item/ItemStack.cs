
using System;
using InventorySystem;
using UnityEngine;


[Serializable]
public class ItemStack : Item
{
    private int _numberItem;
    public int SizeStack => (_itemInfor as IStackAble)!.MaxStack;
    public int NumberItem
    {
        get => _numberItem;
        set
        {
            _numberItem = value >=0 ? value : 0;
           
        }
    }

    public ItemStack(Item itemSo) : base(itemSo)
    {
        _numberItem = (itemSo is IStackAble stackAble) ? stackAble.MaxStack : 0 ;
    }
    public ItemStack(Item_SO itemSo, int numberItem) : base(itemSo)
    {
        _numberItem = numberItem;
    }
    public ItemStack(ItemStack itemObject) : base(itemObject)
    {
        _numberItem = itemObject.NumberItem;
    }

    public void PreviousItem(int quantity)
    {
        if(quantity > NumberItem) return;
        NumberItem -= quantity;
        if(NumberItem == 0) SetEmty();
    }
    public  override void UseItem()
    {
        PreviousItem(1);
    }
    public override void SetEmty()
    {
        _numberItem = 0;
        base.SetEmty();
    }

    public override Item ItemClone()
    {
        return new ItemStack(this);
    }

    public bool CanStackAble()
    {
        return  _numberItem != SizeStack;
    }

    public void AddStack(int quantityAdd, out int requantity)
    {
        var quantitynedd = SizeStack - _numberItem;
        requantity = 0;
        if (quantitynedd < quantityAdd)
        {
            requantity = quantityAdd - quantitynedd;
            _numberItem = SizeStack;
        }
        else
        {
            _numberItem = _numberItem + quantityAdd;
            requantity = quantitynedd;
        }
       
    }
    
    //Check Can add Item Into slot
    public bool CanAddItem(int quantity)
    {
        return quantity + _numberItem <= SizeStack;
    }
    
    //Get Item Slot Stac 
    public ItemStack GetItemSlotStack(int quantity)
    {
        if (quantity > _numberItem) return null;
        ItemStack itemrt = new ItemStack(ItemInfor, quantity);
        PreviousItem(quantity);
        return itemrt;
    }
    
}
