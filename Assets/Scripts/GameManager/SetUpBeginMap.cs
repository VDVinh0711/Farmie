using System.Collections.Generic;
using HelperSystem;
using Player;
using UnityEngine;

public class SetUpBeginMap : MonoBehaviour
{
   
    [SerializeField] private List<Canvas>  _canvasUI;
    [SerializeField] private List<Follow_Target> listFollowPlayer = new();
    [SerializeField] private SpawnPlayerManager _spawnPlayer;
    [SerializeField] private Color Color;
    private void Start()
    {
        SetUp();
        SetUpCamera();
    }
    private void SetUp()
    {
        _spawnPlayer.SpawnPlayer();
        _spawnPlayer.PlayerManager.CameraPlayer.backgroundColor = Color;
        SetUpFollowPlayer();
    }
    
    private void SetUpFollowPlayer()
    {
        foreach (var  followPlayer in listFollowPlayer)
        {
            followPlayer.TargetPos = _spawnPlayer.PlayerSpawm;
        }
    }

    private void SetUpCamera()
    {
        foreach (var canvas in _canvasUI)
        {
            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay) continue;
            print( "set");
            canvas.worldCamera = _spawnPlayer.PlayerManager.CameraPlayer;
        }
    }
}
