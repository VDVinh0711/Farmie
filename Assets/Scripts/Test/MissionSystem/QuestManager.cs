using System;
using MissionSystem;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using UnityEngine;
using Object = UnityEngine.Object;


namespace MissionSystem
{
    public class QuestManager : Singleton<QuestManager>,ISaveSystem
    {
       [SerializeField] private Dictionary<string, Quest> _quests;
       public Dictionary<string, Quest> Quests => _quests;
      
        private void Start()
        {
            LoadMission();
            EventManger<Object>.Registerevent("CheckMission",Check);
        }

        private void  LoadMission()
        {
            if (_quests == null) _quests = new();
            MissionSO[] missionSOs = Resources.LoadAll<MissionSO>("Quest");
            foreach(MissionSO mission in missionSOs) 
            {
                if(_quests.ContainsKey(mission.Id)) continue;
                _quests.Add( mission.Id,LoadQuest(mission));
            }
         

            
        }
        private Quest LoadQuest(MissionSO missionSO)
        {
            switch (missionSO.TypeMission)
            {
                case TypeMission.Crop:
                    return new QuestHarvest(missionSO);
                    break;
                case TypeMission.Breed:
                    return new QuestBreed(missionSO);
                    break;
                case TypeMission.Process:
                    return new QuestProcess(missionSO);
                
            }

            return null;
        }
        private Quest LoadQuest(MissionSO missionSO,int current , bool isDone)
        {
            
            switch (missionSO.TypeMission)
            {
                case TypeMission.Crop:
                    return new QuestHarvest(missionSO,current,isDone);
                    break;
                case TypeMission.Breed:
                    return new QuestBreed(missionSO,current,isDone);
                    break;
                case TypeMission.Process :
                    return new QuestProcess(missionSO, current, isDone);
            }

            return null;
        }
        
        private void Check(Object obj)
        {
            foreach (var quest in _quests.Values)
            {
                if(quest.Isdone) continue;
                quest.CheckMission(obj);
            }
        }

        private void OnDestroy()
        {
            EventManger<Object>.Removeevent("CheckMission",Check);
        }

        public void GetMissonNotDOne()
        {
           
            foreach (var Quest in _quests.Values)
            {
                if (!Quest.Isdone)
                {
                    print(Quest.MissionSo.Name);
                }
            }
        }
        public void GetMissonDOne()
        {
            
            foreach (var Quest in _quests.Values)
            {
                if (Quest.Isdone)
                {
                    print(Quest.MissionSo.Name);
                }
            }
        }
        
      

        public object SaveData()
        {
            Dictionary<string, QuestData> questDatas = new();
            foreach (var questsValue in _quests.Values)
            {
                QuestData questData =new QuestData(questsValue.MissionSo.Id, questsValue.CurrentCount, questsValue.Isdone);
                questDatas.Add(questsValue.MissionSo.Id,questData);
            }

            return questDatas;
        }

        public void LoadData(object state)
        {
            var questDatas = JsonConvert.DeserializeObject<Dictionary<string, QuestData>>(state.ToString());
          
            _quests = new();
            foreach (var questData in questDatas.Values)
            {
                print(MissionSO.GetMissionSObyID(questData.IdMission).TypeMission.ToString());
                _quests.Add(questData.IdMission,LoadQuest(MissionSO.GetMissionSObyID(questData.IdMission),questData.CurrentCount,questData.IsDone));
            }
        }
    }
}


