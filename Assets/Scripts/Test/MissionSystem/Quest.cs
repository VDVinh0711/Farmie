
using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MissionSystem
{
    
    [Serializable]
    public  abstract class Quest
    {
        [SerializeField] protected MissionSO missionSO;
        [SerializeField] protected int _currentcount;
        [SerializeField] protected bool _isDone;

        public event  Action<Quest> changeUI;

        public MissionSO MissionSo => missionSO;

        public int CurrentCount
        {
            get=> _currentcount;
            set
            {
                _currentcount = value > 0 ? value : 0;
                NotifyQuest();
            }
        }
        public bool Isdone => _isDone;
        

        public abstract void FinishMission();

        public  abstract void CheckMission(Object obj);

        private void NotifyQuest()
        {
            changeUI?.Invoke(this);
        }
    }
}

