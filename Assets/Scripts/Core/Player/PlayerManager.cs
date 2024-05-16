

using System;
using InventorySystem;
using Newtonsoft.Json;
using SavingSystem;
using UnityEngine;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>,ISaveData
    {
        [SerializeField] private MovementPlayer _movementPlayer;
        [SerializeField] private PlayerInterac _playerInterac;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private PlayerExperience _playerExperience;
        [SerializeField] private Bag _bag;
        [SerializeField] private ModelPlayerManager _modelPlayerManager;
        [SerializeField] private ModelPlayer _modelPlayer;
      //  [SerializeField] private Camera _cameraPlayer;
        public MovementPlayer MovementPlayer => _movementPlayer;
        public PlayerInterac PlayerInterac => _playerInterac;
        public PlayerStats PlayerStats => _playerStats;
        public PlayerExperience PlayerExperience => _playerExperience;
        public Bag Bag => _bag;
        public ModelPlayerManager ModelPlayerManager => _modelPlayerManager;
        public ModelPlayer ModelPlayer => _modelPlayer;

       // public Camera CameraPlayer => _cameraPlayer;
        
        public object SaveData()
        {
            return new PlayerData(_playerExperience.CurrentLevel, _playerStats.Money, _playerExperience.CurrrentExp);
        }
        public void LoadData(object state)
        {
            var playerdata = JsonConvert.DeserializeObject<PlayerData>(state.ToString());
            _playerStats.Money = playerdata.Money;
            _playerExperience.CurrentLevel = playerdata.Level;
            _playerExperience.CurrrentExp = playerdata.Experience;
          
        }


        private void OnDestroy()
        {
            UIManager.Destroy();
        }
    }
}

