
using System;
using System.Collections.Generic;
using InventorySystem;
using Photon.Pun.Demo.SlotRacer;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerClickHandler
{
   
    [SerializeField] private PlayerManager _player;
    [SerializeField] private Item_SO _itemAdd;


    public void AddItemBagTEST()
    {
        _player.Bag.AddItem(_itemAdd, 3);
    }

    public void TestThamChieu()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var obj = eventData.pointerCurrentRaycast.gameObject;
        if(obj == null) print("null ne ");
        print(obj.gameObject.name);
    }
}


