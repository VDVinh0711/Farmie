using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class UI_ClothesSlotPlayer : UI_ClothesSlot
{
    [SerializeField] private PartPlayerType _partPlayerType;
    [SerializeField] private TextMeshProUGUI _namePartText;
    public PartPlayerType PartPlayerType => _partPlayerType;

    protected override void Start()
    {
        base.Start();
        print((_namePartText == null) +"_" +  _partPlayerType.ToString());
        _namePartText.SetText(_partPlayerType.ToString());
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        var itemClothesController = FindObjectOfType<ItemClothesController>();
        itemClothesController.GetClothesInPlayer(_partPlayerType);
    }
}
