
using InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropAble : MonoBehaviour/*, IDropHandler*/
{

    
    
    public void OnDrop(PointerEventData eventData)
    {
        print(eventData.pointerDrag.gameObject.name);
        print("Droped");
        var dragitem = eventData.pointerDrag.gameObject.GetComponent<DragAble>();
        print(dragitem == null);
        if (dragitem == null) return;
        var thisitem = transform.GetComponent<UI_BagSlots>();
        print(this.gameObject.name);
        var temp =dragitem.Itemholder.Item;
        dragitem.Itemholder = thisitem.Slot.HasItem() ? new ItemSlot(thisitem.Slot.Item) : new ItemSlot();
        thisitem.Slot.Item = temp;

    }


}






    
    

