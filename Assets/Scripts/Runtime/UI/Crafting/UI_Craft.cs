using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;


public class UI_Craft : MonoBehaviour
{

    [SerializeField] private List<UI_CraftSlot> _uiSlots  = new();
    [SerializeField] private CrafSystem _crafSystemSystem;
    [SerializeField] private Transform _panel;
    [SerializeField] private UI_Craft_Product _productCraf;

    [Header("Another OBJ")] 
    [SerializeField] private TextMeshProUGUI _timeUI;
    
    [SerializeField] private Button _btn_Close;
    [Header("Button")] 
    [SerializeField] private Button _btn_Get;
    [SerializeField] private Image _overLayGet;
    [SerializeField] private Button _btn_Craf;
    [SerializeField] private Image _overLayCraft;
    
    [Header("Quantity")] 
    [SerializeField] private Button _btnAdd;
    [SerializeField] private Button _btnPrev;
    [SerializeField] private TextMeshProUGUI _quantityText;

    [Header("Child Of UI Craft")] [SerializeField]
    private UI_Craft_DesScription _uiCraftDesScription;

    private void Awake()
    {
        RegisterEvent();
        SetUpBegin();
        UpdateUiCraft();
    }
    
    private void SetUpBegin()
    {
        for (int i = 0; i < _crafSystemSystem.ListItemCraf.Count; i++)
        {
            _uiSlots[i].AsignInDex(i);
        }

        SetTime(0);
    }
    private void UpdateUiCraft()
    {
        for (int i = 0; i < _crafSystemSystem.ListItemCraf.Count; i++)
        {
            _uiSlots[i].DisPlay(_crafSystemSystem.ListItemCraf[i]);
        }
        SetDes();
    }
    private void UpDateUIItemCreafted()
    {
        _productCraf.DisPlay(_crafSystemSystem.ItemCrafCurrent.ItemCraftSo.itemCrafted,1);
    }
    private void SetTime(int time)
    {
        _timeUI.enabled = _crafSystemSystem.ItemCrafted;
        int minute = time / 60;
        int second = (time % 60);
        _timeUI.SetText(minute + " : " + second);
    }
    private void RegisterEvent()
    {
        _btn_Get.onClick.AddListener(ButtonGetClick);
        _btn_Craf.onClick.AddListener(ButtonCrafClick);
        _btnAdd.onClick.AddListener(ButtonAddclick);
        _btnPrev.onClick.AddListener(ButtonPreviousclick);
        _btn_Close.onClick.AddListener(HideCraf);
        _crafSystemSystem.ActionChangeTImeUI += SetTime;
        _crafSystemSystem.ActionChangeUIDes += SetDes;
        _crafSystemSystem.ActionChangeUIDes += UpDateUIItemCreafted;
        _crafSystemSystem.ActionChangeQuantityCreate += SetTextQuantity;
        _crafSystemSystem.ActionChaneButtonGet_Craft += SetUpButton;
    }
    private void ButtonGetClick()
    {
       _crafSystemSystem.GetItemCrafIntoBag();
       SetUpButton();
    }
    private void ButtonCrafClick()
    {
        if(!_crafSystemSystem.ItemCrafCurrent.enoughItem) return;
        _crafSystemSystem.Craf();
        SetUpButton();
    }
    private void ButtonAddclick()
    {
        
        _crafSystemSystem.AddQuantityCreate();
    }
    private void ButtonPreviousclick()
    {
        _crafSystemSystem.PreviousQuantityCreate();
    }
    private void SetDes()
    {
      
      _uiCraftDesScription.ShowDesScriptTion(_crafSystemSystem.ItemCrafCurrent);
    }
    private void SetTextQuantity()
    {
        _quantityText.SetText(_crafSystemSystem.QuantityCreate+"");
    }
    private void SetUpButton()
    {
        _overLayGet.enabled = !_crafSystemSystem.Canget;
        _overLayCraft.enabled = !_crafSystemSystem.ItemCrafCurrent.enoughItem;
    }
    private void HideCraf()
    {
        _panel.gameObject.SetActive(false);
    }
    private void OpenCraf()
    {
        _panel.gameObject.SetActive(true);
        UpdateUiCraft();
        
    }

    public void ToggleUICraf()
    {
        if (_panel.gameObject.activeSelf)
        {
            HideCraf();
            return;
        }
        OpenCraf();
    }
    
}


