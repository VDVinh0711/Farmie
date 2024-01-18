

using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Player
{
    public class PlayerController : Singleton<PlayerController>,ISaveSystem
    {
        [SerializeField] private MovementPlayer _movementPlayer;
        [SerializeField] private PlayerInterac _playerInterac;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private PlayerExperience _playerExperience;


        public MovementPlayer MovementPlayer => _movementPlayer;
        public PlayerInterac PlayerInterac => _playerInterac;
        public PlayerStats PlayerStats => _playerStats;
        public PlayerExperience PlayerExperience => _playerExperience;


        protected override void Awake()
        {
            base.Awake();
            _movementPlayer = GetComponentInChildren<MovementPlayer>();
            _playerInterac = GetComponentInChildren<PlayerInterac>();
            _playerStats = GetComponentInChildren<PlayerStats>();
            _playerExperience = GetComponentInChildren<PlayerExperience>();
        }
        public object SaveData()
        {
            return new PlayerData(_playerExperience.CurrentLevel, _playerStats.Money, _playerExperience.CurrrentExp,
                transform.position.x, transform.position.y);
        }

        public void LoadData(object state)
        {
            var playerdata = JsonConvert.DeserializeObject<PlayerData>(state.ToString());
            _playerStats.Money = playerdata.Money;
            _playerExperience.CurrentLevel = playerdata.Level;
            _playerExperience.CurrrentExp = playerdata.Experience;
            transform.position = new Vector2(playerdata.Posx, playerdata.Posy);
        }
    }
}

