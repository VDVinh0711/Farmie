using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.XR;

public class DragController : MonoBehaviour
{
    [SerializeField] private ItemMouseHolderData _mouseHolder;





    public void ItemSlotToMouse(UI_Slots uiSlots)
    {
        if(!uiSlots.Slot.HasItem()) return;
       // _mouseHolder.AssignItemAnhUpDateUI(uiSlots.Slot.Item);
        uiSlots.Slot.SetEmty();
    }

    public void MoveItemtoSlot(UI_Slots uiSlots)
    {
        if(!_mouseHolder.ItemHolde.HasItem()) return;
        uiSlots.Slot.Item = _mouseHolder.ItemHolde.Item;
        _mouseHolder.ItemHolde.SetEmty();
        _mouseHolder.ClearUI();
    }

    public void OnLeftClickHandlerUiItemSlot(UI_Slots uiSlots)
    {
        var itemHolder = _mouseHolder.ItemHolde.HasItem() ? _mouseHolder.ItemHolde.Item : null;
        var itemSlot = uiSlots.Slot.HasItem() ? uiSlots.Slot.Item : null;
        if (itemHolder == null && itemSlot != null)
        {
            if (uiSlots.Slot.Item is IStackAble)
            {
                GetOneItemStackForMouse(uiSlots);
                return;
            }
            else
            {
               // _mouseHolder.AssignItemAnhUpDateUI(uiSlots.Slot.Item);
                uiSlots.Slot.SetEmty();
                return;
            }
        }
        if (itemHolder != null && itemSlot != null)
        {
         
            if (itemHolder.ID == itemSlot.ID && itemSlot is IStackAble)
            {
                HandleDecreaseItemMouse(uiSlots);
                return;
            }
            else
            {
                if (itemHolder.ID != itemSlot.ID)
                {
                    SwapItemMouseAndSlot(uiSlots);
                    return;
                }
            }
           
        }
        if (itemHolder != null && itemSlot == null)
        {
            MoveItemMouseForSlot(uiSlots);
            return;
        }
       
    }
    public void OnRightClickHandlerAction(UI_Slots uiSlots)
    {

        var itemholder = _mouseHolder.ItemHolde.HasItem() ? _mouseHolder.ItemHolde.Item : null;
        var itemslot = uiSlots.Slot.HasItem() ? uiSlots.Slot.Item : null;
        
        if (itemholder == null && itemslot != null)
        {
            MoveAllItemForMouse(uiSlots);
            return;
        }
        if (itemholder != null && itemslot != null)
        {
              SwapItemMouseAndSlot(uiSlots);
              return;
        }
        if (itemholder != null && itemslot == null)
        {
            MoveItemMouseForSlot(uiSlots);
            return;
        }
    }
    
    public void MoveItemMouseForSlot(UI_Slots slots)
    {
        print("run");
        if (!_mouseHolder.ItemHolde.HasItem()) return;
        var itemClone = MappingItem.ItemSOtoObj(_mouseHolder.ItemHolde);
        //slots.AssignAndUpDateUI(itemClone);
        _mouseHolder.ItemHolde.SetEmty();
        _mouseHolder.ClearUI();
    }

    public void MoveAllItemForMouse(UI_Slots uiSlots)
    {
        if(!uiSlots.Slot.HasItem()) return;
       _mouseHolder.AssignItemAnhUpDateUI(uiSlots.Slot);
        uiSlots.Slot.SetEmty();
    }

    private void GetOneItemStackForMouse(UI_Slots uiSlots)
    {
        if(!uiSlots.Slot.HasItem()) return;
        var uiSlotStack = (uiSlots.Slot.Item as IStackAble);
        if(uiSlotStack == null) return ;
      //  uiSlotStack.DecreseStacK(1);
        var cloneItem = uiSlots.Slot.Item;
        //(cloneItem as IStackAble).CurrentStack = 1;
       // _mouseHolder.AssignItemAnhUpDateUI(cloneItem);
        uiSlots.UpDateUi();
    }

    private void HandleDecreaseItemMouse(UI_Slots uiSlots)
    {
      
        if(!uiSlots.Slot.HasItem()) return;
       // (_mouseHolder.ItemHolde.Item as IStackAble)!.AddStack(1);
        //(uiSlots.Slot.Item as IStackAble).DecreseStacK(1);
        uiSlots.UpDateUi();
        _mouseHolder.UpdateUI();

    }

    private void SwapItemMouseAndSlot(UI_Slots uiSlots)
    {
        if(!uiSlots.Slot.HasItem() || !_mouseHolder.ItemHolde.HasItem()) return;
        var temp = _mouseHolder.ItemHolde.Item;
       // _mouseHolder.AssignItemAnhUpDateUI(uiSlots.Slot.Item);
       // uiSlots.AssignAndUpDateUI(temp);
        uiSlots.Slot.Item = temp;
    }
    
}
