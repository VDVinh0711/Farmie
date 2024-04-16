
using System;
using InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAble : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler
{


    [SerializeField] private Transform _DragHolder;
    [SerializeField] private Vector3 _StartPos;
    [SerializeField] private Transform _originParent;
    [SerializeField] public ItemSlot Itemholder;
    public void OnDrag(PointerEventData eventData)
    {
        this.gameObject.transform.SetParent(_DragHolder);
        this.gameObject.transform.position =eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _originParent = this.gameObject.transform.parent;
        _StartPos = this.gameObject.transform.position;
        var slot= transform.parent.gameObject.GetComponent<UI_BagSlots>().Slot;
        if(!slot.HasItem()) return;
        Itemholder = new ItemSlot(slot.Item);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.gameObject.transform.SetParent(_originParent);
        this.gameObject.transform.position = _StartPos;
        var slot= transform.parent.gameObject.GetComponent<UI_BagSlots>().Slot;
        if (!Itemholder.HasItem())
        {
            slot.SetEmty();
        }
        else
        {
            slot.Item = Itemholder.Item;
        }
        Itemholder.SetEmty();
    }


 
}
