
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Infor : MonoBehaviour,IPointerClickHandler
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
   }
   private void ShowInfor()
   {
      _panel.gameObject.SetActive(true);
   }
   public void OnPointerClick(PointerEventData eventData)
   {
      UI_inforTroggle();
   }


}
