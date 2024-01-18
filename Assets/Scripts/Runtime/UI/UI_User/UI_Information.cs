
using System;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Information : MonoBehaviour
{
    [SerializeField] private Image _imageAVT;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private Slider _process;
    private void Start()
    {
        UpdateExperience(PlayerController.Instance.PlayerExperience);
        PlayerController.Instance.PlayerExperience.StateChange += UpdateExperience;
    }


    private void UpdateExperience(PlayerExperience playerExperience)
    {
        _process.maxValue = playerExperience.LevelPlayer.Levels[playerExperience.CurrentLevel];
        _title.SetText("Nhà nông cấp  " + playerExperience.CurrentLevel);
        print(playerExperience.CurrrentExp);
        _process.value = playerExperience.CurrrentExp;
    }
    private void OnDestroy()
    {
        PlayerController.Instance.PlayerExperience.StateChange += UpdateExperience;
    }
}
