
using Player;
using SavingSystem;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    [SerializeField] private SavingDataFarm _savingDataFarm;
    private void Awake()
    {
        LoadDataFarm();
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
        UIManager.Destroy();
    }
}
