using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class UI_Craft : MonoBehaviour
{

    [SerializeField] private List<UI_CraftSlot> _uiSlots  = new();
    [SerializeField] private CrafSystem _crafSystem;
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
        for (int i = 0; i < _crafSystem.ListItemCraf.Count; i++)
        {
            _uiSlots[i].AsignInDex(i);
        }
      
    }
    
    private void SetUpBegin()
    {

        SetTime(0);
        UpdateUiCraft();
    }
    private void UpdateUiCraft()
    {
        for (int i = 0; i < _crafSystem.ListItemCraf.Count; i++)
        {
            _uiSlots[i].DisPlay(_crafSystem.ListItemCraf[i]);
        }
        SetDes();
    }
    private void UpDateUIItemCreafted()
    {
        _productCraf.DisPlay(_crafSystem.ItemCrafCurrent.ItemCraftSo.itemCrafted,_crafSystem.QuantityCreate);
    }
    private void SetTime(int time)
    {
        _timeUI.enabled = _crafSystem.IsCraf;
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
        _crafSystem.ActionChangeTImeUI += SetTime;
        _crafSystem.ActionChangeUIDes += SetDes;
        _crafSystem.ActionChangeUIDes += UpDateUIItemCreafted;
        _crafSystem.ActionChangeQuantityCreate += SetTextQuantity;
        _crafSystem.ActionChaneButtonGet_Craft += SetUpButton;
    }
    private void ButtonGetClick()
    {
       _crafSystem.GetItemCrafIntoBag();
       SetUpButton();
    }
    private void ButtonCrafClick()
    {
        if(!_crafSystem.ItemCrafCurrent.enoughItem) return;
        _crafSystem.Craf();
        SetUpButton();
    }
    private void ButtonAddclick()
    {
        _crafSystem.AddQuantityCreate();
        SetUpButton();
    }
    private void ButtonPreviousclick()
    {
        _crafSystem.PreviousQuantityCreate();
        SetUpButton();
    }
    private void SetDes()
    {
      _uiCraftDesScription.ShowDesScriptTion(_crafSystem.ItemCrafCurrent);
    }
    private void SetTextQuantity()
    {
        _quantityText.SetText(_crafSystem.QuantityCreate+"");
    }
    private void SetUpButton()
    {
        _overLayGet.enabled = !_crafSystem.Canget;
        _overLayCraft.enabled = _crafSystem.QuantityCreate <= 0;
    }
    private void HideCraf()
    {
        _panel.gameObject.SetActive(false);
    }
    private void OpenCraf()
    {
        _panel.gameObject.SetActive(true);
        SetUpBegin();

    }
    public void ToggleUICraf()
    {
        print("toggel");
        if (_panel.gameObject.activeSelf)
        {
            HideCraf();
            return;
        }
        OpenCraf();
    }
  
}


