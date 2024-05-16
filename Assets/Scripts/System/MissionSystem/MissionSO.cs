
using UnityEngine;
using UnityEngine.Serialization;


namespace MissionSystem
{
   
    public class MissionSO : ScriptableObject
    {
         public string Id;
         public string Name;
         public string keyDes;
         public int ExpReward;
         public int GoldReward;
         public int DimondReward;
         public int CountRequest;
         public TypeMission TypeMission;

        protected virtual void OnValidate()
        {
            Id = this.name;
        }

        public static MissionSO GetMissionSObyID(string ID)
        {
            var itemlist = Resources.LoadAll<MissionSO>("ScriptAbleOBJ/Quest");
            foreach (var item in itemlist)
            {
                if (!item.Id.Equals(ID))  continue;
                return item;
            }
            return null;
        }
    }
}
