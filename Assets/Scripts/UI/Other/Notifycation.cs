
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notifycation : MonoBehaviour
{
   [SerializeField] private Transform _panel;
   [SerializeField] private TextMeshProUGUI _textMessage;
   [SerializeField] private Button _btnOk;

   private void Start()
   {
      _panel = transform.GetChild(0).transform;
      _textMessage = _panel.GetChild(1).GetComponent<TextMeshProUGUI>();
      _btnOk = _panel.GetChild(2).GetComponent<Button>();
      RegisterEvent();
   }

   private void RegisterEvent()
   {
      _btnOk.onClick.AddListener(Hide);
      EventManger<string>.Removeevent("ShowNotifycation",ShowMessage);
      EventManger<string>.Registerevent("ShowNotifycation",ShowMessage);
   }

   private void ShowMessage(string message)
   {
      Show();
      _textMessage.SetText(message);
   }

   private void Show()
   {
      UIManager.OpenUI(_panel);
   }

   private void Hide()
   {
      UIManager.HideUI(_panel);
   }
   

}
