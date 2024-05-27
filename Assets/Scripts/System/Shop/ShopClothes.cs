using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Player;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Serialization;

public class ShopClothes : MonoBehaviour,IInterac
{
    [SerializeField] private List<ItemShopClothes> _listClothes  = new ();
    [SerializeField] private int _curentIndexActive = -1;
    [SerializeField] private UI_ShopClothes _uiShopClothes;
    [SerializeField] private PlayerManager playerManager;

    public PlayerManager PlayerManager => playerManager;
    public ItemShopClothes ItemCrentActive => _listClothes[_curentIndexActive];
    public int LengtClothes => _listClothes.Count;
    private void Start()
    {
        _curentIndexActive = -1;
        ActiveItem(0);
    }
    public List<ItemShopClothes> ListClothes => _listClothes;
    public void PurChareClothes()
    {
        if(!(ItemCrentActive.itemShopObject is Itemshop itemSHopClothes)) return;
        var price = ItemCrentActive.itemShopObject.Price;
        var bag = playerManager.Bag;
        if (bag == null) return;
        if(bag.AddItem(  FactoryItem.CreateItem(itemSHopClothes.itemdata))) playerManager.PlayerStats.Spend(price);
    }
    public void ActiveItem(int  indexActive)
    {
        if (indexActive == _curentIndexActive)
        {
            _listClothes[indexActive].isActive = false;
            _curentIndexActive = -1;
            return;
        }
        if(_curentIndexActive >=0 && _curentIndexActive < LengtClothes)     _listClothes[_curentIndexActive].isActive = false;
        _curentIndexActive = indexActive;
        _listClothes[_curentIndexActive].isActive = true;
        _uiShopClothes.ShowDesScripte();
    }
    

    public void InterRac(PlayerManager playerManager)
    {
        this.playerManager = playerManager;
        _uiShopClothes.Toggle();
    }

    private void OnMouseDown()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        _uiShopClothes.Toggle();
    }
}

[Serializable]
public class ItemShopClothes
{
    [SerializeField] private bool _isActive;
    public bool isActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            OnStateChange();
        }
    }
    public Itemshop itemShopObject;
    public Action<ItemShopClothes> satechangeUI;
    public ItemShopClothes(bool isActive, Itemshop itemShopClothes)
    {
        this.isActive = isActive;
        this.itemShopObject = itemShopClothes;
    }

    private void OnStateChange()
    {
        satechangeUI?.Invoke(this);
    }
    
}
