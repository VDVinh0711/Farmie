using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Test : MonoBehaviour
{
   [SerializeField] private ItemObject carrot;



   public void AddTest()
   {
      EventManger<Object>.RaiseEvent("CheckMission",carrot);
   }

   public void AddExperien()
   {
      PlayerController.Instance.PlayerExperience.AddExperience(100);
   }

   public void SkipTIme()
   {
     // TimeManager.Instance.SetupTime(300);
 
     Debug.Log(GameTime.ShowTime(GameTime.GetRealTIme()));
   }
}
