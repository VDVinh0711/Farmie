using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.Serialization;

public class ClothesPlayerManager : MonoBehaviour
{
    [SerializeField] private List<ClothesItemDiction> _clotheItemsPlayer;
    [SerializeField] public Bag _bag;
    [SerializeField] private ModelPlayer _modelPlayer;
    public List<ClothesItemDiction> ClothesItemDictions =>_clotheItemsPlayer;
    public ModelPlayer ModelPlayer;
    public void UpdateModelPlayer()
    {
        foreach (var clothesItem in _clotheItemsPlayer)
        {
            if(!clothesItem.itemClothes.HasItem()) continue;
            foreach (var partPlayer in _modelPlayer._listpartPlayer)
            {
                if(clothesItem.partPlayerType != partPlayer.typePartPlayer) continue;
                _modelPlayer.Set(partPlayer.typePartPlayer,(clothesItem.itemClothes.Item  as ClothesItemSO ).SoBodyPart);
            }
        }
    }
    public void ChangeclotheItemPlayer(PartPlayerType type , ItemSlot itemClothes)
    {
        if (!(itemClothes.Item is ClothesItemSO)) return;
        foreach (var  clothesItem in _clotheItemsPlayer)
        {
            if(type != clothesItem.partPlayerType) continue;
            if (clothesItem.itemClothes.HasItem())
            {
                var Bag = FindObjectOfType<Bag>();
                Bag.AddItem(clothesItem.itemClothes);
            }

            clothesItem.itemClothes = itemClothes;
            
            UpdateModelPlayer();
        }
    }
}
[Serializable]
public class ClothesItemDiction
{
     public PartPlayerType partPlayerType;
     public ItemSlot itemClothes;
}

