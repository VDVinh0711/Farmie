using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class ModelPlayerController : MonoBehaviour
{
    [SerializeField] private ModelPlayerManager _modelPlayerManager;
    [SerializeField] private Bag _bag;



    public void BackClothesInBag(ItemSlot item)
    {
        _bag.AddItem(item.Item);
        item.SetEmty();
        _modelPlayerManager.UpdateModelPlayer();
    }
    
}
