using System;

using InventorySystem;
using Shop123;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActiveComfirmSell : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;
    [SerializeField] private TextMeshProUGUI _nameItem;
    [SerializeField] private TMP_InputField _inputQuantity;
    [SerializeField] private Button _btnCancle;
    [SerializeField] private Button _btnSellAll;
    [SerializeField] private Button _btnOk;
    private SellItem _sellitem;
    private UIShop _uiShop;
    private ItemSlot _itemsell;

    private void Awake()
    {
        Hide();
        _uiShop = GameObject.FindObjectOfType<UIShop>();
    }

    private void Start()
    {
        Getcomponent();
        RegisterEvent();
    }

    private void Getcomponent()
    {
        _nameItem = _panel.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _inputQuantity = _panel.GetComponentInChildren<TMP_InputField>();
        _btnCancle = _panel.GetChild(3).GetChild(0).GetComponent<Button>();
        _btnSellAll = _panel.GetChild(3).GetChild(1).GetComponent<Button>();
        _btnOk = _panel.GetChild(3).GetChild(2).GetComponent<Button>();
        
    }

    private void RegisterEvent()
    {
        _btnCancle.onClick.AddListener(()=>{Hide();});
        _btnSellAll.onClick.AddListener(SellAll);
        _btnOk.onClick.AddListener(OKClick);
        _inputQuantity.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            if (text.Length >= 2) return addedChar = '\0';
            return ValidateChar("0123456789", addedChar);
        };
    }

    public void Show(ItemSlot item)
    {
        if(item.Item == null) return;
        _nameItem.SetText(item.Item.ID);
        _inputQuantity.text = "";
        _itemsell = item;
        _panel.gameObject.SetActive(true);
        _sellitem = new SellItem(Bag.Instance);
     
    }

    public void Hide()
    {
        _panel.gameObject.SetActive(false);
    }

    private void SellAll()
    {
       _sellitem.SellAll(_itemsell);
       _uiShop.InventoryShop.RenderInvenInShop();
       Hide();

    }
    private void OKClick()
    {
        var quantity = Int32.Parse(_inputQuantity.text.ToString());
        _sellitem.SellEachItem(_itemsell, quantity);
        _uiShop.InventoryShop.RenderInvenInShop();
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