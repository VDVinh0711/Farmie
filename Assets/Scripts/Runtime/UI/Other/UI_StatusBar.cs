
using UnityEngine;
using InventorySystem;
using Player;
using TMPro;
using UnityEngine.UI;
public class UI_StatusBar : MonoBehaviour
{
    [Header("Hand")]
    [SerializeField] private Image _thumail;
    [SerializeField] private TextMeshProUGUI _quantity;
    [SerializeField] private Slider _durability_UI;
    [Header("Money")] 
    [SerializeField] private TextMeshProUGUI _money;

    
    private void Awake()
    {
        _thumail = transform.GetChild(0).GetChild(0).GetComponentInChildren<Image>();
        _quantity = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _money = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        _durability_UI = transform.GetComponentInChildren<Slider>();
        _durability_UI.interactable = false;
    }

    private void Start()
    {
        Display();
    }

    private void UpdateHandStatusbar(ItemSlot itemSlot)
    {
        itemSlot.StatechangeUI -= OnstateChangeHand;
        if(itemSlot == null) return;
        var isStack = itemSlot.IsstackAble;
        var hasItem = itemSlot.HasItem();
        var isdurability = itemSlot is ItemSlotDura && hasItem;
        _durability_UI.transform.gameObject.SetActive(isdurability);
        _thumail.enabled = hasItem; 
        _quantity.enabled = isStack;
        itemSlot.StatechangeUI += OnstateChangeHand;
        if (!hasItem) return;
        _thumail.sprite = itemSlot.Item.UIinInven;
        setduraUI(itemSlot);
        settext(itemSlot);
    }
    private void OnstateChange()
    {
        Display();
    }
    public void Display()
    {
        BagsManager.Instance.StateChange -= OnstateChange;
        BagsManager.Instance.StateChange += OnstateChange;
        var money = PlayerController.Instance.PlayerStats.Money;
        UpdateHandStatusbar(BagsManager.Instance.HandItem);
        UpdateMoneyStatusBar();
    }
    
    private void setduraUI(ItemSlot item)
    {
        var itemdura = item as ItemSlotDura;
        var itemobj = item.Item as AgriculturalObject;
        if (itemdura == null && itemobj == null) return;
        _durability_UI.maxValue = itemobj.Durability;
        _durability_UI.value = itemdura.Durability;
    }

    private void settext(ItemSlot item)
    {
        var itemstack = item as ItemSlotStack;
        if(itemstack == null) return;
        _quantity.SetText(itemstack.NumberItem.ToString());
    }
    private void OnstateChangeHand(ItemSlot arg)
    {
        UpdateHandStatusbar(arg);
    }
    private void OnstateChangeMoney()
    {
        UpdateMoneyStatusBar();
    }
    private void UpdateMoneyStatusBar()
    {
        PlayerController.Instance.PlayerStats.StateChange -= OnstateChangeMoney;
        _money.SetText( "<wave>"+PlayerController.Instance.PlayerStats.Money.ToString() + "$ </wave>");
        PlayerController.Instance.PlayerStats.StateChange += OnstateChangeMoney;
    }
}
