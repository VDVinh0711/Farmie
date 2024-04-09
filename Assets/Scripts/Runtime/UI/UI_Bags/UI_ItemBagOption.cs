
using UnityEngine;
using UnityEngine.UI;
namespace InventorySystem
{
    public class UI_ItemBagOption :  MonoBehaviour ,IActionAccept
    {
        [SerializeField] private Button _btn_Use;
        [SerializeField] private Button _btn_AddInven;
        [SerializeField] private Button _btn_Dispose;
        [SerializeField] private ItemSlot _slotActive;
        [SerializeField] private BagOptionsController _bagOptionsController;
        [SerializeField] private int _curIndexSlot;
        public  void Start()
        {
            /*_btn_Use = transform.GetChild(0).GetComponent<Button>();
            _btn_AddInven = transform.GetChild(1).GetComponent<Button>();
            _btn_Dispose = transform.GetChild(2).GetComponent<Button>();*/
            _btn_Use.onClick.AddListener(UseItemClick);
            _btn_AddInven.onClick.AddListener(AddInvenClick);
            _btn_Dispose.onClick.AddListener(DisposeClick);
        }
        public void ShowOption(ItemSlot itemSlot, int indexslot)
        {
            _slotActive = itemSlot;
            _curIndexSlot = indexslot;
            gameObject.SetActive(true);
        }
        public void UseItemClick()
        {
            _slotActive.IsActive = false;
            _bagOptionsController.UseItem(_curIndexSlot);
            gameObject.SetActive(false);
        }
        private void AddInvenClick()
        {
           _bagOptionsController.AddItemtoInventory(_slotActive);
           HideOption();
        }
        private void DisposeClick()
        {
            ComfirmManager.Intance.Show("Bạn có muốn vứt vật phẩm này không ? Mất hết",this);
        }
        public void ActionAccept()
        {
           _bagOptionsController.DisposeItem(_slotActive);
           _slotActive.IsActive = false;
            HideOption();
        }
        public void HideOption()
        {
            gameObject.SetActive(false);
            _slotActive.IsActive = false;
        }
    }
}

