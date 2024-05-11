using System;
using InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAbleV2 : MonoBehaviour,IPointerClickHandler
{

    [SerializeField] private DragController _dragController;
    [SerializeField] private UI_Slots _uiSlots;

    private event Action ActionRightClick;
    private event  Action ActionLeftClick;
    private void Start()
    {
        _uiSlots = gameObject.GetComponent<UI_Slots>();
       // OnRegisterEvent();
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        EventSystem.current.SetSelectedGameObject(this.gameObject);
        if(_uiSlots.Slot.IsActive) return;
        switch (eventData.button)
       {
           case PointerEventData.InputButton.Left :
               ActionLeftClick?.Invoke();
               break;
           case PointerEventData.InputButton.Right :
               ActionRightClick?.Invoke();
               break;
       }
    }
    
    /*
    private void OnRegisterEvent()
    {
        ActionRightClick +=  ()=>_dragController.OnRightClickHandlerAction(_uiSlots);
        ActionLeftClick += () => _dragController.OnLeftClickHandlerUiItemSlot(_uiSlots);

    }*/
}
