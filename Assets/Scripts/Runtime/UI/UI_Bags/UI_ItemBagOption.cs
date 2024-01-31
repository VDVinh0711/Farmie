
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace InventorySystem
{
    public class UI_ItemBagOption : AbsCheckOutSide,IActionAccept
    {
        [SerializeField] private Button _btn_Use;
        [SerializeField] private Button _btn_AddInven;
        [SerializeField] private Button _btn_Dispose;
        [SerializeField] private UI_BagSlots _uiBagsSlot;
        [SerializeField] private BagOptionsController _bagOptionsController;
        public  void Start()
        {
            _btn_Use = transform.GetChild(0).GetComponent<Button>();
            _btn_AddInven = transform.GetChild(1).GetComponent<Button>();
            _btn_Dispose = transform.GetChild(2).GetComponent<Button>();
            _btn_Use.onClick.AddListener(UseItemClick);
            _btn_AddInven.onClick.AddListener(AddInvenClick);
            _btn_Dispose.onClick.AddListener(DisposeClick);
        }
        
        public void ShowOption(UI_BagSlots uibagslot)
        {
            _uiBagsSlot = uibagslot;
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                _uiBagsSlot.Slot.IsActive = false;
                RemoveClick();
                return;
            }
            gameObject.SetActive(true);
            regisclick();
        }
        public void UseItemClick()
        {
            _bagOptionsController.UseItem(_uiBagsSlot);
            HideOption();
        }
        private void AddInvenClick()
        {
           _bagOptionsController.AddItemtoInventory(_uiBagsSlot);
           HideOption();
        }
        private void DisposeClick()
        {
            ComfirmManager.Intance.Show("Bạn có muốn vứt vật phẩm này không ? Mất hết",this);
        }
        
        public void ActionAccept()
        {
           _bagOptionsController.DisposeItem(_uiBagsSlot);
            _uiBagsSlot.Slot.IsActive = false;
            HideOption();
        }

        protected override void Click(InputAction.CallbackContext obj)
        {
            if(!_isOutSide) return;
            _uiBagsSlot.Slot.IsActive = false;
            HideOption();
        }

        private void HideOption()
        {
            gameObject.SetActive(false);
        }
    }
}

