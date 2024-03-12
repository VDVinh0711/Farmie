
using System;
using InventorySystem;
using Player;
using UnityEngine;

[Serializable]
public class ItemClothesController : MonoBehaviour
{

    [SerializeField] private ClothesPlayerManager _clothesPlayerManager;
    [SerializeField] private Bag _playerBag;
    [SerializeField] private UI_Clothes _uiClothes;
    [SerializeField] private PlayerController _playerController;

    public void AddItemInPlayer(ItemSlot itemSlot)
    {
        var partPlayerType = (itemSlot.Item as ClothesItemSO  ).partPlayerType;
       
        if (partPlayerType == null) return;
       // if(_playerController.PlayerExperience.CurrentLevel >  (itemSlot.Item as ClothesItemSO).LevelRequired ) return;
        ItemSlot clothesinPlayer = null;
        foreach (var clothesItemDiction in _clothesPlayerManager.ClothesItemDictions)
        {
            if(clothesItemDiction.partPlayerType != partPlayerType) continue;
            if(!clothesItemDiction.itemClothes.HasItem()) break;
            clothesinPlayer = new ItemSlot(clothesItemDiction.itemClothes);
        }
        ItemSlot itemtemp = new ItemSlot(itemSlot);
        _clothesPlayerManager.ChangeclotheItemPlayer(partPlayerType, itemtemp);
        _playerBag.RemoveItem(itemSlot, 1);
        _uiClothes.RenderClothesUI();
        _playerBag.AddItem(clothesinPlayer);
    }

    public void GetClothesInPlayer(PartPlayerType type)
    {
        foreach (var clothesItemDiction in _clothesPlayerManager.ClothesItemDictions)
        {
            if(clothesItemDiction.partPlayerType != type) continue;
            if(!clothesItemDiction.itemClothes.HasItem()) break;
            ItemSlot itemSlottemp = new ItemSlot(clothesItemDiction.itemClothes);
            _playerBag.AddItem(itemSlottemp);
            clothesItemDiction.itemClothes.SetEmty();
            _uiClothes.RenderClothesUI();
            
        }
    }

}
