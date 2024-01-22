
using System;
using InventorySystem;
using UnityEngine;


public class ItemSlotStack : ItemSlot
{
    private int _numberItem;
    public int SizeStack => (Item as IStackAble).MaxStack;
    public int NumberItem
    {
        get => _numberItem;
        set
        {
            _numberItem = value;
            OnStateChange();
        }
    }
    public ItemSlotStack(ItemObject itemObject, int numberItem) : base(itemObject)
    {
        NumberItem = numberItem;
    }
    public ItemSlotStack(ItemSlotStack itemObject) : base(itemObject)
    {
        NumberItem = itemObject.NumberItem;
    }

    public void PreviousItem(int quantity)
    {
        if(quantity > NumberItem) return;
        NumberItem -= quantity;
        if(_numberItem == 0) SetEmty();
    }

    public  override void UseItem()
    {
        NumberItem -= 1;
        if(NumberItem <=0) SetEmty();
    }
    public override void SetEmty()
    {
        base.SetEmty();
        NumberItem = 0;
    }
    public bool CanStackAble()
    {
        return  _numberItem != SizeStack;
    }

    public bool CanAddItem(int quantity)
    {
        return quantity + _numberItem <= SizeStack;
    }
}
