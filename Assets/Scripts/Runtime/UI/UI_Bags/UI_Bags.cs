
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace InventorySystem
{
public class UI_Bags : AbsCheckOutSide
{
    [SerializeField] private GameObject _inventorySLotPrefabs;
    [SerializeField] private UI_BagSlots _uiHandplayer;
    [SerializeField] private TextMeshProUGUI _uiShowDescripton;
    [SerializeField] private TextMeshProUGUI _uiShowNameItem;
    [SerializeField] private List<UI_BagSlots> _slots;
    [SerializeField] private Transform root;
    [SerializeField] private UI_ItemBagOption _uiItemBagOption;

    public UI_ItemBagOption UIItemBagOption => _uiItemBagOption;
    
    private void Start()
    {
        root = transform.GetChild(0).GetChild(2);
        InstanstializeBag();
    }
    public void InstanstializeBag()
    {
        if (_inventorySLotPrefabs == null) return;
        for (int i=0;i< BagsManager.Instance.Size; i++)
        {
            var UISLot = Instantiate(_inventorySLotPrefabs,root);
            var UIslotScript = UISLot.gameObject.GetComponent<UI_BagSlots>();
            UIslotScript.AssighIndex(i);
            //UIslotScript.Display(BagsManager.Instance.Slot[i]);
            UIslotScript.showDesEvent += ShowUIDescription;
            _slots.Add(UIslotScript);
        }
        _uiHandplayer.Display(BagsManager.Instance.HandItem );
       RenderBags();
      BagsManager.Instance.StateChange += RenderBags;
    }
    private void RenderBags()
    {
      
        for(int i=0;i<_slots.Count;i++)
        {
            _slots[i].Display(BagsManager.Instance.Slot[i]);
        }   
        _uiHandplayer.Display(BagsManager.Instance.HandItem );
    }
    private void ShowUIDescription(string nameItem , string description)
    {
        if(_uiShowDescripton == null || _uiShowNameItem == null) return;
        _uiShowDescripton.SetText(description);
        _uiShowNameItem.SetText(nameItem);
    }
    public void ShowBags()
    {
        var uishow = root.parent.transform;
        if (uishow.gameObject.activeSelf)
        {
            UIManager.HideUI(root.parent.transform);
            RemoveClick();
            return;
        }
       
       RenderBags(); 
        UIManager.OpenUI(root.parent.transform);
        regisclick();
    }

    protected  override void Click(InputAction.CallbackContext obj)
    {
        
        if (_isOutSide)
        {
            UIManager.HideUI((root.parent.transform));
            _isOutSide = false;
        }
    }

}
}

