



using System;
using UnityEngine;
using UnityEngine.EventSystems;


namespace InventorySystem
{
    public class UI_BagSlots :UI_Slots,IPointerEnterHandler, IPointerClickHandler,IPointerExitHandler
    {

        #region BackUp Old Version

        /* #region Prop
        [SerializeField] protected InventorySlot _slot;
        [SerializeField] public int _indexOfSlot;
        [SerializeField] private UI_DisplayItem _uiItem;
        [SerializeField] private UI_Bags _uiBags;
        public InventorySlot Slot => _slot;
        public event Action<string,string> showDesEvent;
        protected FarmInputAction _farmInputAction;
        [SerializeField] protected bool isPressShift = false;
        #endregion
        
        private void Start()
        {
            _uiBags = FindObjectOfType<UI_Bags>();
            _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
            _farmInputAction = new FarmInputAction();
            _farmInputAction.Enable();
            _farmInputAction.InteracPlayer.ShiftHold.performed += ShiftPress;
            _farmInputAction.InteracPlayer.ShiftHold.canceled += ShiftOut;
        }
        
        public void Display(InventorySlot item)
        {
            if (item == null) return;
            _slot = item;
            if(_uiItem == null) _uiItem = transform.GetComponentInChildren<UI_DisplayItem>();
            _uiItem.UpdateView(_slot);
        }
        public void AssighIndex(int index)
        {
            _indexOfSlot = index;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            string name = _slot.HasItem() ? _slot.Item.name : " ";
            /*var des = GameMultiLang.Instance.currentlang.Equals("vn")
                ? _slot.Item.DescriptionVN
                : _slot.Item.DescriptionEN;*/
         /**   string description = _slot.HasItem() ?  "đâsd" : " ";
            showDesEvent?.Invoke(name,description);
        }
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (isPressShift)
            {
                BagsManager.Instance.InventoHand(_indexOfSlot);
                return;
            }
            _slot.IsActive = true;
            _uiBags.UIItemBagOption.ShowOption(this);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            showDesEvent?.Invoke("","");
        }
        
        public int getIndexItem()
        {
            return _indexOfSlot;
        }

        public InventorySlot getData()
        {
            return _slot;
        }

        private void ShiftPress(InputAction.CallbackContext obj)
        {
            print(obj);
            isPressShift = true;
        }

        private void ShiftOut(InputAction.CallbackContext obj)
        {
            print(obj);
            isPressShift = false;
        }*/

        #endregion
       
         [SerializeField] private UI_Bags _uiBags;

         [SerializeField] private BagOptionsController _bagOptionsController;
         public event Action<string, string> ShowItemDescriptionEvent;

         protected override void Start()
         {
             base.Start();
             _uiBags = FindObjectOfType<UI_Bags>();
             _bagOptionsController = FindObjectOfType<BagOptionsController>();
         }
         public virtual void OnPointerEnter(PointerEventData eventData)
         {
             DisplayItemDescription();
         }
         public virtual void OnPointerExit(PointerEventData eventData)
         {
             ClearItemDescription();
         }
         public virtual void OnPointerClick(PointerEventData eventData)
         {
             HandlePointerClick(eventData.button);
         }

         private void DisplayItemDescription()
         {
             if (!_slot.HasItem()) return;
             string name = _slot.Item.name;
             string description = GameMultiLang.GetTraduction(_slot.Item.KeyDes);
             ShowItemDescriptionEvent?.Invoke(name, description);
         }
         private void ClearItemDescription()
         {
             ShowItemDescriptionEvent?.Invoke("", "");
         }

         private void HandlePointerClick(PointerEventData.InputButton button)
         {
             if (!_slot.HasItem()) return;
             if (button == PointerEventData.InputButton.Left)
             {
                 _bagOptionsController.AcctiveItemInBag(this);
             }
             else if (button == PointerEventData.InputButton.Right)
             {
                 DeactivateSlotAndTransferItemToHand();
             }
             
             //đây là cách fix cho chạy được  về phần UI , backend vẫn hoạt động tốt
             /*Chi tiết bug : khi click active các slot chức năng vẫn chạy bình thường, nhưng khi thực hiện chức năng swap giữa hand và item trong bag
              . Khi click active vào item thì những ô slot đãtuwngfg lưu item này ều bị thay đổi theo giống như item đang được active , nhưng trong
              phần hiển  thị backend thì giá trị vẫn đúng  (nghi ngờ bug do tham chiếu  địa chỉ bị lỗi) , nhưng khi render lại thì vẫn hoạt động bình thường*/
             _uiBags.RenderBagContents();
         }
         private void DeactivateSlotAndTransferItemToHand()
         {
             Slot.IsActive = false;
             Bag.Instance.InventoHand(_indexOfSlot);
         }
    }
}

