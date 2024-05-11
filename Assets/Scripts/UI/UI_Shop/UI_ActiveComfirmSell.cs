
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UI_Shop
{
    public class UI_ActiveComfirmSell : MonoBehaviour
    {
       
        [SerializeField] private RectTransform _panel;
        [SerializeField] private TextMeshProUGUI _nameItem;
        [SerializeField] private TMP_InputField _inputQuantity;
        [SerializeField] private Button _btnCancle;
        [SerializeField] private Button _btnSellAll;
        [SerializeField] private Button _btnOk;
        [SerializeField] private ShellItemController _shellItem;
        [SerializeField] private Button _btnsell;
        private void Awake()
        {
            RegisterEvent();
            Hide();
        }
        private void RegisterEvent()
        {
            _btnCancle.onClick.AddListener(()=>{Hide();});
            _btnSellAll.onClick.AddListener(SellAll);
            _btnOk.onClick.AddListener(OKClick);
            _btnsell.onClick.AddListener(Show);
            _inputQuantity.onValidateInput = (string text, int charIndex, char addedChar) =>
            {
                if (text.Length >= 2) return addedChar = '\0';
                return ValidateChar("0123456789", addedChar);
            };
        }
        private void SetupBegin()
        {
            _inputQuantity.text = string.Empty;
            _nameItem.SetText(_shellItem.Itemsell.Itemslot.Item.ItemInfor.name);
        }
        public void Show( )
        {
            if(!_shellItem.Itemsell == null) return;
            SetupBegin();
         _panel.gameObject.SetActive(true);
        }
    
        public void Hide()
        {
            _panel.gameObject.SetActive(false);
        }
        private void SellAll()
        {
            _shellItem.SellAllItem();
           Hide();
        }
        private void OKClick()
        {
            var quanititysell = int.Parse(_inputQuantity.text.Trim());
            if(quanititysell > _shellItem.maxQuantityShell) return;
            _shellItem.SellItem();
            Hide();
        }
        private char ValidateChar(string validateCharacter, char addedChar)
        {
            if (validateCharacter.Contains(addedChar))
            {
                //valid
                return addedChar;
            }
                //Invalid
            return '\0';
        }
    }
}
