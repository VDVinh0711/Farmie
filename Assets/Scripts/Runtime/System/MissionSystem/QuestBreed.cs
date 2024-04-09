using System;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MissionSystem
{ 
    [Serializable]
    public class QuestBreed : Quest
    {
        
        
        public QuestBreed (){}

        public QuestBreed(MissionSO missionSo)
        {
            this.missionSO = missionSo;
            _currentcount = 0;
            _isDone = false;

        }public QuestBreed(MissionSO missionSo, int current , bool isDone)
        {
            this.missionSO = missionSo;
            _currentcount = current;
            _isDone = isDone;

        }
        public override void FinishMission()
        {
            PlayerManager.Instance.PlayerStats.Earn(missionSO.GoldReward);
            PlayerManager.Instance.PlayerExperience.AddExperience(missionSO.ExpReward);
        }

        public override void CheckMission(Object obj)
        {
            var animal = obj as AnimalObject;
            if(animal == null) return;
            if( !animal.id.Equals((missionSO as MissionSOBreed).AnimalObject.id)) return;
            CurrentCount++;
            Debug.Log(_currentcount);
            if(_currentcount < missionSO.CountRequest) return;
            _isDone = true;
            FinishMission();
        }
    }

}
