
using System;
using UnityEngine;
using InventorySystem;
using Player;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class UI_StatusBar : MonoBehaviour
{

    [SerializeField] private Bag _bag;
    [FormerlySerializedAs("_playerController")] [SerializeField] private PlayerManager playerManager;
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
        _bag.HandItem.StateActionChange -= OnStateActionChange;
        _bag.HandItem.StateActionChange += OnStateActionChange;
        var hasitem = itemSlot.HasItem();
        _thumail.enabled = hasitem;
        _quantity.enabled = false;
        _durability_UI.transform.gameObject.SetActive(false);
        if (!hasitem) return;
        _thumail.sprite = itemSlot.Item.UIinInven;
        switch (itemSlot)
        {
            case ItemSlotStack:
                SetUpUiStack(itemSlot as ItemSlotStack);
                break;
            case ItemSlotDura:
                SetUiDuraable(itemSlot as ItemSlotDura);
                break;
        }

    }

    private void SetUiDuraable(ItemSlotDura itemSlotDura)
    {
        if (itemSlotDura == null) return;
        _durability_UI.transform.gameObject.SetActive(true);
        _durability_UI.maxValue = (itemSlotDura.Item as AgriculturalSo).MaxDurability;
        _durability_UI.value = itemSlotDura.CurDurability;
    }

    private void SetUpUiStack(ItemSlotStack itemSlotStack)
    {
        if ( itemSlotStack == null) return;
        _quantity.enabled = true;   
        _quantity.SetText(itemSlotStack.NumberItem.ToString());
    }

    public void Display()
    {
        _bag.StateChangeHand+= UpdateHandStatusbar;
        UpdateHandStatusbar(_bag.HandItem);
        UpdateMoneyStatusBar();
    }
    
    private void OnstateChangeMoney()
    {
        UpdateMoneyStatusBar();
    }
    private void UpdateMoneyStatusBar()
    {
        playerManager.PlayerStats.StateChange += OnstateChangeMoney;
        _money.SetText( PlayerManager.Instance.PlayerStats.Money.ToString());
        
    }

    private void OnDestroy()
    {
        playerManager.PlayerStats.StateChange -= OnstateChangeMoney;
        _bag.StateChangeHand -= UpdateHandStatusbar;
    }
    private void OnStateActionChange(ItemSlot arg)
    {
        UpdateHandStatusbar(arg);
    }
}
