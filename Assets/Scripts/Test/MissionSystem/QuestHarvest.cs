
using System;
using Player;
using Object = UnityEngine.Object;


namespace MissionSystem
{
    [Serializable]
    public class QuestHarvest : Quest
    {
    
        public QuestHarvest(){}

        public QuestHarvest(MissionSO missionSo)
        {
            this.missionSO = missionSo;
            _currentcount = 0;
            _isDone = false;
        }

        public QuestHarvest(MissionSO missionSo, int current, bool isdone)
        {
            this.missionSO = missionSo;
            _currentcount = current;
            _isDone = isdone;
        }
        public override void FinishMission()
        {
            PlayerController.Instance.PlayerStats.Earn(missionSO.GoldReward);
            PlayerController.Instance.PlayerExperience.AddExperience(missionSO.ExpReward);
        }

        public override void CheckMission(Object obj)
        { 
            var item = obj as ItemObject;
            if(item == null) return;
            if(! item.ID.Equals((missionSO as MissionSOHarvest).ItemObject.ID)) return;
            CurrentCount++;
            if(_currentcount < missionSO.CountRequest) return;
            _isDone = true;
            FinishMission();
        }
    }
}

