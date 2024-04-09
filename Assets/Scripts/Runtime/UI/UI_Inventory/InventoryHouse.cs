
using Player;
using UnityEngine;

namespace  InventorySystem
{
    public class InventoryHouse : MonoBehaviour,IInterac
    {

        [SerializeField] private UI_Inventory _uiInventory;
        

        public void InterRac(PlayerManager playerManager)
        {
            _uiInventory.ShowInventory();
        }
    }

}
