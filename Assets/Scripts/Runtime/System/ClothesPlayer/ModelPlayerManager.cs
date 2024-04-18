using System;
using InventorySystem;
using UnityEngine;


public class ModelPlayerManager : MonoBehaviour
{
    
    [Header("Part")]
    [SerializeField] private PartsPlayer[] _listPartPlayer;
    [Header("Clothes")]
    [SerializeField] private ItemClothes[] _listClothesPlayer;
    [SerializeField] private ModelPlayer _modelPlayer;
    [SerializeField] private Bag _bag;
    public Action StateChangeUI;
    public PartsPlayer[] ListPartPlayers => _listPartPlayer;
    public ItemClothes[] ListClothesPlayer => _listClothesPlayer;
    
    public void SetClothesPlayer(ItemSlotClothes itemSlotClothes)
    {
        foreach (var itemclothes in _listClothesPlayer)
        {
            if(itemSlotClothes.Type != itemclothes.type) continue;
            SwapClothesandBag(itemclothes.itemClothes,itemSlotClothes);
        }
        UpdateModelPlayer();
    }
    private void SwapClothesandBag( ItemSlotClothes itemslotClothes ,ItemSlotClothes  itemSlotClothesBag)
    {
        _bag.BagController.SwapWithItemInBag(itemSlotClothesBag,itemslotClothes);
        UpdateModelPlayer();
    }
    public void BackClothesInBag(ItemSlotClothes itemSlotClothes)
    {
        if(! _bag.AddItem(itemSlotClothes.Item, 1)) return;
        itemSlotClothes.SetEmty();
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
            _modelPlayer.SetClothesPlayer(clothesPlayer.type,(clothesPlayer.itemClothes.Item as ClothesItem_SO));
        }
        OnStateChangeUI();
    }
    private void OnStateChangeUI()
    {
        StateChangeUI?.Invoke();
    }
    

}

[Serializable]
public class ItemClothes
{
    public CLothesType type;
    public ItemSlotClothes itemClothes;
}
[Serializable]
public class PartsPlayer
{
    public BodyPartType type;
    public PartPlayerModel_SO partPlayer;
}



