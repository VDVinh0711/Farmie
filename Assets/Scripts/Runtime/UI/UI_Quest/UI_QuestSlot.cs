
using System;
using TMPro;
using UnityEngine;

namespace MissionSystem
{
    public class UI_QuestSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtTitle;
        [SerializeField] private TextMeshProUGUI _txtProcess;
        [SerializeField] private TextMeshProUGUI _txtDes;
        [SerializeField] private TextMeshProUGUI _txtGold;
        [SerializeField] private TextMeshProUGUI _txtExp;
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
            _quest.changeUI += UpdateQuest;
            _txtTitle.SetText(quest.MissionSo.Name);
            _txtDes.SetText(quest.MissionSo.description);
            _txtProcess.SetText(quest.CurrentCount+"/"+quest.MissionSo.CountRequest);
            _txtGold.SetText(quest.MissionSo.GoldReward.ToString());
            _txtExp.SetText(quest.MissionSo.ExpReward.ToString());
        }
    }
}

    
