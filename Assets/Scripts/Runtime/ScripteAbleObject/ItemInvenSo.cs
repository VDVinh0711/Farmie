
using System;
using UnityEngine;
[CreateAssetMenu(menuName = "New ItemData/Item Inventory")]
public class ItemInvenSo : Item_SO,IStackAble
{
    [SerializeField]
    private float _price;
    public float Price =>_price;
    public int MaxStack { get=>6; }
    public int CurrentStack { get; set; }
    
    
    public void DecreseStacK(int quantity)
    {
        if (CurrentStack > quantity) return;
        CurrentStack -= quantity;
    }

    public int AddStack(int quantity)
    {
        var numberloss = MaxStack - CurrentStack;
        if (quantity > numberloss)
        {
            CurrentStack = MaxStack;
            return quantity - numberloss;
        }

        CurrentStack += quantity;
        return 0;
    }

    public Action ActionChange { get; set; }
}
