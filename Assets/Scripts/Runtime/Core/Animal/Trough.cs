
using System;
using System.Collections.Generic;
using InventorySystem;
using Player;
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
    private Bag _bag;
    public void InterRac(PlayerManager playerManager)
    {
        _bag = playerManager.Bag;
        EquidmentSo eqidItem = _bag.HandItem.Item as EquidmentSo;
        if(eqidItem == null) return;
        eqidItem.Used(this);
        _bag.HandItem.UseItem();
    }
}
