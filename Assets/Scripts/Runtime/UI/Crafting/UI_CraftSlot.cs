
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CraftSlot : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private CrafSystem _crafSystem;
    [SerializeField] private Image _imageDisplay;
    [SerializeField] private Image _imageOverlay;
    [SerializeField] private Image _imageActive;
    [SerializeField] private int index;
    public  void DisPlay(ItemCraf itemCraf)
    {
        if(itemCraf == null) return;
       
        RegisterActiveChangr(itemCraf);
        _imageDisplay.sprite = itemCraf.ItemCraftSo.Sprite;
        var oonovl = itemCraf.enoughItem;
        _imageOverlay.enabled = !oonovl;
        _imageActive.enabled = itemCraf.IsActive;

    }


    public void AsignInDex(int index)
    {
        this.index = index;
    }

    private void RegisterActiveChangr(ItemCraf itemCraf)
    {
        itemCraf.OnActionChange -= DisPlay;
        itemCraf.OnActionChange += DisPlay;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _crafSystem.ChangeActive(index);
    }
}
