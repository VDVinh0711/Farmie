using System.Collections.Generic;
using HelperSystem;
using Player;
using UnityEngine;

public class SetUpBeginMap : MonoBehaviour
{
   
    [SerializeField] private Canvas _canvasUI;
    [SerializeField] private List<Follow_Target> listFollowPlayer = new();
    [SerializeField] private SpawnPlayerManager _spawnPlayer;
    
    private void Start()
    {
        SetUp();
    }
    private void SetUp()
    {
        _spawnPlayer.SpawnPlayer();
        SetUpCanvas(_spawnPlayer.PlayerManager);
        SetUpFollowPlayer();
    }
    private void SetUpCanvas(PlayerManager playerManager)
    {
        _canvasUI.worldCamera = playerManager.CameraPlayer;
    }
    private void SetUpFollowPlayer()
    {
      
        foreach (var  followPlayer in listFollowPlayer)
        {
            followPlayer.TargetPos = _spawnPlayer.PlayerSpawm;
        }
    }
}
