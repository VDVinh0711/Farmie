
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
  
}
