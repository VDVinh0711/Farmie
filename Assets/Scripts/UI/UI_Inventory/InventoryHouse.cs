
using Player;
using UnityEngine;

namespace  InventorySystem
{
    public class InventoryHouse : MonoBehaviour,IInterac
    {

        [SerializeField] private UI_Inventory _uiInventory;
        [SerializeField] private Inventory _inventory;

        public void InterRac(PlayerManager playerManager)
        {
            _uiInventory.ToggelInventory();
            _inventory.AssignPlayer(playerManager);
        }
    }

}
