
using System;
using Player;
using SavingSystem;
using UnityEngine;
using PlayFab;

public class FarmManager : MonoBehaviour
{
    [SerializeField] private SavingDataFarm _savingDataFarm;
    [SerializeField] private Vector3 _posPlayerBeGinFarm;
    private void Awake()
    {
        SetFarmWhenBegin();
        LoadDataFarm();
    }
    private void SetFarmWhenBegin()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.gameObject.transform.position = _posPlayerBeGinFarm;
    }
    public void LoadDataFarm()
    {
        _savingDataFarm.LoadData();
    }
    public void LoadSaveDataFarm()
    {
        _savingDataFarm.LoadSaveData();
    }
    private void OnDestroy()
    {
        LoadSaveDataFarm();
    }
}
