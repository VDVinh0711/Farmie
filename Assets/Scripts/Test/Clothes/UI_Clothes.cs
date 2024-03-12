using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using InventorySystem;
using UnityEngine;

public class UI_Clothes : MonoBehaviour
{

    [SerializeField] private List<UI_ClothesSlotPlayer> _uiSlotClothesPlayer;
    [SerializeField] private ClothesPlayerManager _clothesPlayerManager;
    [SerializeField] private Transform _slotItemPre;
    [SerializeField] private Transform _rootSpawn;
    [SerializeField] private Transform _panelui;
    [SerializeField] private Animator _animatorPreview;


    private void Start()
    {
        AddAnimatorCtrlPreview();
    }


    private void AddAnimatorCtrlPreview()
    {
        var animatorPlayer = FindObjectOfType<BodypartController>().AnimatorPlayer;
        _animatorPreview.runtimeAnimatorController = animatorPlayer.runtimeAnimatorController;
    }

    public void RenderUiSlotClothesPlayer()
    {
        //Get all item of player
        
        foreach (var clothespart in _clothesPlayerManager.ClothesItemDictions)
        {
           // if(!clothespart.itemClothes.HasItem()) continue;
            foreach (var uiClothesSlot in _uiSlotClothesPlayer)
            {
                if(clothespart.partPlayerType != uiClothesSlot.PartPlayerType) continue;
                uiClothesSlot.Display(clothespart.itemClothes);
            }
        }
        
    }
    public void RenderItemClothes()
    {

        RefeshUi();
        for (int i = 0; i < _clothesPlayerManager._bag.GetItemClothesInBag().Count; i++)
        {
            var itemspawn = Instantiate(_slotItemPre, _rootSpawn).GetComponentInChildren<UI_Slots>();
            itemspawn.Display(_clothesPlayerManager._bag.GetItemClothesInBag()[i]);
        }
       
    }
    private void RefeshUi()
    {
        foreach (var itemOBj in _rootSpawn.GetComponentsInChildren<UI_ClothesSlot>())
        {
         
            Destroy(itemOBj.gameObject);
        }
    }
    private void ShowUIClothes()
    {
        RenderClothesUI();
        _panelui.gameObject.SetActive(true);
    }
    private void HideUiClothes()
    {
        _panelui.gameObject.SetActive(false);
    }

    public void ToggleUiClothes()
    {
        if (_panelui.gameObject.activeSelf)
        {
            HideUiClothes();
            return;
        }
        ShowUIClothes();
        
    }

    public void RenderClothesUI()
    {
        RenderUiSlotClothesPlayer();
        RenderItemClothes();
    }
}
