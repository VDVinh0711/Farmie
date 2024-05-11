
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class UI_BagHandSlot : UI_BagSlots
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
          //Bag.Instance.ItemInHandToBag();
          var bag = FindObjectOfType<Bag>();
          bag.BagController.IteminHandtoBag();
        }
    }  
    
}


