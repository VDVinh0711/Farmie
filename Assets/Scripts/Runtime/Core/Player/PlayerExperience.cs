
using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Player
{
    public class PlayerExperience : MonoBehaviour
    {
        [SerializeField] private int _currentLevel = 1;
        [SerializeField] private int _currentExp = 0;
        private LevelPlayer _levelPlayer = new LevelPlayer();
        public event Action<PlayerExperience> StateChange;
        public LevelPlayer LevelPlayer => _levelPlayer;
        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value > 0 ? value : 0;
                EventManger<Object>.RaiseEvent("CheckMission",this);
                OnStateChange();
            }
        }

        public int CurrrentExp
        {
            get => _currentExp;
            set
            {
                _currentExp = value > 0 ? value : 0;
                OnStateChange();
            }
        }
        public void AddExperience(int exp)
        {
            CurrrentExp+= exp;
            if (_currentExp < _levelPlayer.Levels[CurrentLevel]) return;
            CurrentLevel += 1;
            CurrrentExp = 0;
        }

        private void OnStateChange()
        {
            StateChange?.Invoke(this);
        }

      
    }
}

