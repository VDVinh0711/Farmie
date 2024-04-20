using System;
using InventorySystem;
using UnityEngine;


public class ModelPlayerManager : MonoBehaviour
{
    
    [Header("Part")]
    [SerializeField] private PartsPlayer[] _listPartPlayer;
    [Header("Clothes")]
    [SerializeField] private ItemSlotClothes[] _listClothesPlayer;
    [SerializeField] private ModelPlayer _modelPlayer;
    [SerializeField] private Bag _bag;
    public Action StateChangeUI;
    public PartsPlayer[] ListPartPlayers => _listPartPlayer;
    public ItemSlotClothes[] ListClothesPlayer => _listClothesPlayer;
    
    public void SetClothesPlayer(ItemSlot itemClothesSet)
    {
        if(!(itemClothesSet.Item is ItemClothes clothes))  return;
        foreach (var itemclothes in _listClothesPlayer)
        {
            if(clothes.Type != itemclothes.type) continue;
            ItemHelper.SwapWithItemSlot(itemclothes.itemClothes, itemClothesSet);
        }
        UpdateModelPlayer();
    }
    public void SetPartPlayer(PartPlayerModel_SO partPlayerModelSo)
    { 
        foreach (var partsPlayer in _listPartPlayer)
        {
            if(partsPlayer.type != partPlayerModelSo.Type) continue;
            partsPlayer.partPlayer = partPlayerModelSo;
        }
        UpdateModelPlayer();
    }
    public void UpdateModelPlayer()
    {
        foreach (var partsPlayer in _listPartPlayer)
        {
            if (partsPlayer.partPlayer == null) continue;
            _modelPlayer.SetPartPlayer(partsPlayer.type , partsPlayer.partPlayer);
        }
        foreach (var clothesPlayer in _listClothesPlayer)
        {
            var clothesset = !clothesPlayer.itemClothes.HasItem() ? null: (clothesPlayer.itemClothes.Item.ItemInfor as ClothesItem_SO);
            _modelPlayer.SetClothesPlayer(clothesPlayer.type,clothesset);
        }
        OnStateChangeUI();
    }
    private void OnStateChangeUI()
    {
        StateChangeUI?.Invoke();
    }
    

}

[Serializable]
public class ItemSlotClothes
{
    public CLothesType type;
    public ItemSlot itemClothes;
}
[Serializable]
public class PartsPlayer
{
    public BodyPartType type;
    public PartPlayerModel_SO partPlayer;
}



