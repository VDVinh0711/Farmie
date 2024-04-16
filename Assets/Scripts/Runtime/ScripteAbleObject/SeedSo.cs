
using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New ItemData/Seed")]
public class SeedSo : EquidmentSo,IStackAble
{
    [SerializeField]
    private int _daytoGrow;
    [SerializeField]
    private List<Sprite> _spriteGrow;
    [SerializeField]
    private Item_SO _itemHarvset;

    public int DaytoGrow => _daytoGrow;
    public List<Sprite> SpriteGrow => _spriteGrow;
    public Item_SO ItemHarvest => _itemHarvset;

    public override void Used(UnityEngine.Object data)
    {
        var land = data as Land;
        if(land == null) return;
        land.SeedingPlant(this);
        CurrentStack -= 1;
    }


      public int MaxStack { get => 6; }
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
