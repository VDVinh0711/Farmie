using System;
using UnityEngine;


namespace MissionSystem
{
   
    public class MissionSO : ScriptableObject
    {
        [SerializeField] public string Id;
        [SerializeField] public string Name;
        [SerializeField] public string description;
        [SerializeField] public int ExpReward;
        [SerializeField] public int GoldReward;
        [SerializeField] public int DimondReward;
        [SerializeField] public int CountRequest;
        [SerializeField] public TypeMission TypeMission;

        protected virtual void OnValidate()
        {
            Id = this.name;
        }

        public static MissionSO GetMissionSObyID(string ID)
        {
            var itemlist = Resources.LoadAll<MissionSO>( "Quest");
            foreach (var item in itemlist)
            {
                if (item.Id.Equals(ID))
                    return item;
            }
            return null;
        }
    }
}
