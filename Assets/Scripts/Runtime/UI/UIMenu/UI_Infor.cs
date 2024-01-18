
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UI_Infor : AbsCheckOutSide,IPointerClickHandler
{

   [SerializeField] private RectTransform _panel;
   private void UI_inforTroggle()
   {
      if (_panel.gameObject.activeSelf)
      {
         HideInfor();
         return;
      }

      ShowInfor();
   }

   private void HideInfor()
   {
      _panel.gameObject.SetActive(false);
      RemoveClick();
   }

   private void ShowInfor()
   {
      _panel.gameObject.SetActive(true);
      regisclick();
   }

   public void OnPointerClick(PointerEventData eventData)
   {
      UI_inforTroggle();
   }

   protected override void Click(InputAction.CallbackContext obj)
   {
      if(!_isOutSide) return;
      HideInfor();
   }
}
