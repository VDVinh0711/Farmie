
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
            PlayerManager.Instance.PlayerStats.Earn(missionSO.GoldReward);
            PlayerManager.Instance.PlayerExperience.AddExperience(missionSO.ExpReward);
        }

        public override void CheckMission(Object obj)
        { 
            var item = obj as Item_SO;
            if(item == null) return;
            if(! item.ID.Equals((missionSO as MissionSOHarvest).itemSo.ID)) return;
            CurrentCount++;
            if(_currentcount < missionSO.CountRequest) return;
            _isDone = true;
            FinishMission();
        }
    }
}

