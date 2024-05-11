
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MissionSystem
{
    public class UI_QuestSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtTitle;
        [SerializeField] private TextMeshProUGUI _txtProcess;
        [SerializeField] private TextMeshProUGUI _txtDes;
        [SerializeField] private TextMeshProUGUI _txtGold;
        [SerializeField] private TextMeshProUGUI _txtExp;
        [SerializeField] private Image _iconGold;
        [SerializeField] private Image _iconExp;
        [SerializeField] private Quest _quest;


        public void UpdateQuest(Quest quest)
        {
            print("call this function");
            _txtProcess.SetText(quest.CurrentCount+"/"+quest.MissionSo.CountRequest);
        }

        public void Display(Quest quest)
        {
            if(quest == null) return;
            _quest = quest;
            var hasGold = quest.MissionSo.GoldReward != 0;
            var hasExp = quest.MissionSo.ExpReward != 0;
            _quest.changeUI += UpdateQuest;
            _txtTitle.SetText(quest.MissionSo.Name);
            _txtDes.SetText(quest.MissionSo.description);
            _txtProcess.SetText(quest.CurrentCount+"/"+quest.MissionSo.CountRequest);
            _txtGold.enabled = hasGold;
            _iconGold.enabled = hasGold;
            _txtExp.enabled = hasExp;
            _iconExp.enabled = hasExp;
            _txtGold.SetText(quest.MissionSo.GoldReward.ToString());
            _txtExp.SetText(quest.MissionSo.ExpReward.ToString());
        }
    }
}

    
