using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace MissionSystem
{
    public class UIQuest : MonoBehaviour,IPointerClickHandler
    {
        [SerializeField] private RectTransform _panelQuest;
        [SerializeField] private Transform _questPre;
        [SerializeField] private Transform _root;
        [SerializeField] private Dictionary<string, UI_QuestSlot> _questSlots ;
        [SerializeField] private Button _btnClose;

        private void Awake()
        {
            _btnClose.onClick.AddListener(HideMission);
        }

        private void IntantiateMission()
        {
            if (_questSlots == null) _questSlots = new();
            foreach (var quest in MissionOfPlayer.Instance.Quests.Values)
            {
                if(_questSlots.ContainsKey(quest.MissionSo.Id) ) continue;
                var QuestSpawn = Instantiate(_questPre, _root);
                var questScript = QuestSpawn.transform.GetComponent<UI_QuestSlot>();
                questScript.Display(quest);
                _questSlots.Add(quest.MissionSo.Id,questScript);
            }
        }
        private void MissionPanelTroggel()
        {
            if (_panelQuest.gameObject.activeSelf)
            {
                HideMission();
                return;
            }
            ShowMission();
        }
        private void ShowMission()
        {
            UIManager.OpenUI(_panelQuest);
            IntantiateMission();
         
        }
        private void HideMission()
        {
            UIManager.HideUI(_panelQuest);
           
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            MissionPanelTroggel();
        }
    }
    
    

}
