using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UI_ClothesPlayer : MonoBehaviour
{
    [SerializeField] private List<DictionSLotUiCLothes> _listUiCLothes;
    [SerializeField] private ModelPlayerManager _modelPlayerManager;
    [SerializeField] private ModelPreViewPlayer _modelPreViewPlayer;
    [SerializeField] private RectTransform _panel;
    private void Awake()
    {
        _modelPlayerManager.StateChangeUI -= DisPlayUiClothesPlayer;
        _modelPlayerManager.StateChangeUI += DisPlayUiClothesPlayer;
    }
    private void SetUpBegin()
    {
        foreach (var uiCLothe in _listUiCLothes)
        {
            uiCLothe.SetText();
        }

        DisPlayItemClothesPlayer();
        SetUpPreViewPlayer();
    }
    private void DisPlayUiClothesPlayer()
    {
        DisPlayItemClothesPlayer();
        SetUpPreViewPlayer();
    }
    private void DisPlayItemClothesPlayer()
    {
        foreach (var clothesPlayer in _modelPlayerManager.ListClothesPlayer)
        {
          
            foreach (var uiclothes in _listUiCLothes)
            {
                if(clothesPlayer.type != uiclothes.type) continue;
                uiclothes.UIClothesItemSlot.Display(clothesPlayer.itemClothes);
            }
        }
    }
    private void SetUpPreViewPlayer()
    {
        foreach (var clothesPLayer in _modelPlayerManager.ListClothesPlayer)
        {
            _modelPreViewPlayer.SetClothesPlayer( clothesPLayer.type,(clothesPLayer.itemClothes.Item as ClothesItem_SO));
        }
    }
    private void ShowUIClothes()
    {
        _panel.gameObject.SetActive(true);
        SetUpBegin();
    }
    private void HideUiClothes()
    {
        _panel.gameObject.SetActive(false);
    }
    public void ToggleUiClothes()
    {
        if (_panel.gameObject.activeSelf)
        {
            HideUiClothes();
            return;
        }
        ShowUIClothes();
        
    }
}


[Serializable]
public class DictionSLotUiCLothes
{
    public CLothesType type;
    public UI_ClothesItemSlot UIClothesItemSlot;
    public TextMeshProUGUI textShow;

    public void SetText()
    {
        textShow.SetText(type.ToString());
    }
}
