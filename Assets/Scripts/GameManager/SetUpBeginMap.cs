using System.Collections.Generic;
using HelperSystem;
using UnityEngine;



public class SetUpBeginMap : MonoBehaviour
{
   
    [SerializeField] private List<Follow_Target> listFollowPlayer = new();
    [SerializeField] private SpawnPlayerManager _spawnPlayer;
   
    private void Start()
    {
        SetUp();
    }
    private void SetUp()
    {
        _spawnPlayer.SpawnPlayer();
        SetUpFollowPlayer();
    }
    
    private void SetUpFollowPlayer()
    {
        foreach (var  followPlayer in listFollowPlayer)
        {
            followPlayer.TargetPos = _spawnPlayer.PlayerSpawm;
        }
    }
    
  

   
}
