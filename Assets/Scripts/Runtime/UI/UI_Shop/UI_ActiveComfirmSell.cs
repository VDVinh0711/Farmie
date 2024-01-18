using System;

using InventorySystem;
using Shop123;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActiveComfirmSell : MonoBehaviour
{

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
        _nameItem = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _inputQuantity = transform.GetComponentInChildren<TMP_InputField>();
        _btnOk = transform.GetChild(3).GetChild(1).GetComponent<Button>();
        _btnCancle = transform.GetChild(3).GetChild(0).GetComponent<Button>();
        _btnSellAll = transform.GetChild(3).GetChild(2).GetComponent<Button>();
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
        print(item.Item == null);
        if(item.Item == null) return;
        _nameItem.SetText(item.Item.name);
        _inputQuantity.text = "";
        _itemsell = item;
        _sellitem = new SellItem(BagsManager.Instance);
        gameObject.SetActive(true);
        //Validate for input text field
       
    }

    public void Hide()
    {
        gameObject.SetActive(false);
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
