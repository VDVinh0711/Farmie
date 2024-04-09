
using UnityEngine;
using System;
using Newtonsoft.Json;


namespace Player
{
    public class PlayerStats : MonoBehaviour 
    {
         private  float money  = 10000;

        public float Money
        {
            get => money;
            set
            {
                money = value > 0 ? value : 0;
            }
        }
        public event Action StateChange;
        public  void Spend(float cost)
        {
            if(cost > money)
            {
                return;
            }
            money -= cost;
            OnstateChange();

        }
        public  void Earn(float moneyadd)
        {
            money+= moneyadd;
            OnstateChange();
        }
        private void OnstateChange()
        {
            StateChange?.Invoke();
        }
    }

}

