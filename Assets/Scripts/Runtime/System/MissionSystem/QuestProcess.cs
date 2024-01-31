
using System;

using Player;
using UnityEngine;
using Object = UnityEngine.Object;


namespace MissionSystem
{
    public class QuestProcess : Quest
    {
        
        
        public QuestProcess() {}
        public QuestProcess(MissionSO missionSo)
        {
            this.missionSO = missionSo;
            _currentcount = 0;
            _isDone = false;

        }
        public QuestProcess(MissionSO missionSo,int currrent, bool isdone)
        {
            this.missionSO = missionSo;
            _currentcount = currrent;
            _isDone = isdone;
        }
        public override void FinishMission()
        {
            PlayerController.Instance.PlayerStats.Earn(missionSO.GoldReward);
        }

        public override void CheckMission(Object obj)
        {
            var exp = obj as PlayerExperience;
            if(exp == null) return;
            CurrentCount = exp.CurrentLevel;
            if(CurrentCount != missionSO.CountRequest) return;
            _isDone = true;
            FinishMission();
        }
        
        
    }

}
