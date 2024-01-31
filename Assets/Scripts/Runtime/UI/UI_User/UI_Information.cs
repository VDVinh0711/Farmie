
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Information : MonoBehaviour
{
    [SerializeField] private Image _exp;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private PlayerController _playerController;
    private void Start()
    {
        UpdateExperience(_playerController.PlayerExperience);
        _playerController.PlayerExperience.StateChange += UpdateExperience;
    }
    private void UpdateExperience(PlayerExperience playerExperience)
    {
        var valueAmount = (playerExperience.CurrrentExp) / (playerExperience.LevelPlayer.Levels[playerExperience.CurrentLevel]);
        _title.SetText( playerExperience.CurrentLevel.ToString());
        _exp.fillAmount = valueAmount;
        
    }
    private void OnDestroy()
    {
        _playerController.PlayerExperience.StateChange -= UpdateExperience;
    }
}
