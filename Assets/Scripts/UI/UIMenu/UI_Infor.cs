
using System;
using MissionSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Infor : MonoBehaviour
{

   [Header("Button ")]
   [SerializeField] private Button _btn_Chat;
   [SerializeField] private Button _btn_Quest;
   [SerializeField] private Button _btn_ClothesPlayer;
   [SerializeField] private Button _toggleUI;

   [Header("UI")] 
   [SerializeField] private UIQuest _uiQuest;
   [SerializeField] private UI_ChatPanel _uiChat;
   [SerializeField] private UI_ClothesPlayer _uiClothes;

   [SerializeField] private RectTransform _panel;

   private void Awake()
   {
      RegisterEvent();
      
   }

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

   public void RegisterEvent()
   {
      _btn_Chat.onClick.AddListener(_uiChat.UIChatTroggle);
      _btn_Quest.onClick.AddListener(_uiQuest.MissionPanelTroggel);
      _btn_ClothesPlayer.onClick.AddListener(_uiClothes.ToggleUiClothes);
      _toggleUI.onClick.AddListener(UI_inforTroggle);
   }
   

}
