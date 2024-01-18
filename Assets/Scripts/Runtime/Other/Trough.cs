
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;


public class Trough : MonoBehaviour,IInterac
{
    protected bool _hasFood = false;
    public bool HasFood
    {
        get => _hasFood;
        set
        {
            _hasFood = value;
            spriteTrough.sprite = value ? stateTrough[1] : stateTrough[0];
            if (value) return;
            transform.GetComponentInParent<Stable>().UnsetStateEat();
        }
    }
    [SerializeField] private List<Sprite> stateTrough = new(2);
    [SerializeField]  private SpriteRenderer spriteTrough;
    public virtual void InterRac()
    {
        EquidmentObject eqidItem = BagsManager.Instance.HandItem.Item as EquidmentObject;
        if(eqidItem == null) return;
        eqidItem.Used(this);
        BagsManager.Instance.HandItem.UseItem();
    }

   
 
}
