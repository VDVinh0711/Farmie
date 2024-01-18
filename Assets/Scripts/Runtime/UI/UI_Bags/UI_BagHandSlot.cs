
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class UI_BagHandSlot : UI_BagSlots
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
          BagsManager.Instance.HandtoInventory();
        }
    }  
    
}


