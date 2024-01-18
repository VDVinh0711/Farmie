
using UnityEngine;

namespace  InventorySystem
{
    public class InventoryHouse : MonoBehaviour,IInterac
    {

        [SerializeField] private UI_Inventory _uiInventory;
    

        public void InterRac()
        {
            _uiInventory.ShowInventory();
        }
    }

}
