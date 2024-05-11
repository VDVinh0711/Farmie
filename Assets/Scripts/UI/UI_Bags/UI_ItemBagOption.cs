
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
namespace InventorySystem
{
    public class UI_ItemBagOption :  MonoBehaviour ,IActionAccept
    {
        [SerializeField] private Button _btn_Use;
        [SerializeField] private Button _btn_AddInven;
        [SerializeField] private Button _btn_Dispose;
        [SerializeField] private ItemSlot active;
        [SerializeField] private BagOptionsController _bagOptionsController;
        [SerializeField] private int _curIndexSlot;
        public  void Start()
        {
           
            _btn_Use.onClick.AddListener(UseItemClick);
            _btn_AddInven.onClick.AddListener(AddInvenClick);
            _btn_Dispose.onClick.AddListener(DisposeClick);
        }
        public void ShowOption(ItemSlot item, int indexslot)
        {
            active = item;
            _curIndexSlot = indexslot;
            gameObject.SetActive(true);
        }
        public void UseItemClick()
        {
            active.IsActive = false;
            _bagOptionsController.UseItem(_curIndexSlot);
            gameObject.SetActive(false);
        }
        private void AddInvenClick()
        {
           _bagOptionsController.AddItemtoInventory(active);
           HideOption();
        }
        private void DisposeClick()
        {
            ComfirmManager.Intance.Show("Bạn có muốn vứt vật phẩm này không ? Mất hết",this);
        }
        public void ActionAccept()
        {
           _bagOptionsController.DisposeItem(active);
           active.IsActive = false;
            HideOption();
        }
        public void HideOption()
        {
            gameObject.SetActive(false);
            active.IsActive = false;
        }
    }
}

