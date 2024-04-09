using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class SpawnPlayerManager : MonoBehaviour
{
   [SerializeField] private Transform _playerSpawnPre;
   [SerializeField] private Vector3 _posSpawnPlayer;
   private PlayerManager _playerManager;
   public Transform PlayerSpawm;
   public PlayerManager PlayerManager => _playerManager;
   
   
   public void SpawnPlayer()
   {
      PlayerSpawm = Instantiate(_playerSpawnPre);
      PlayerSpawm.position = _posSpawnPlayer;
      _playerManager = PlayerSpawm.GetComponent<PlayerManager>();
   }
   
}
