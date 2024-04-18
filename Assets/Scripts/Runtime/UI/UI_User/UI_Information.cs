
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Information : MonoBehaviour
{
    [SerializeField] private Image _exp;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private PlayerManager playerManager;
    private void Start()
    {
        UpdateExperience(playerManager.PlayerExperience);
        playerManager.PlayerExperience.StateChange += UpdateExperience;
    }
    private void UpdateExperience(PlayerExperience playerExperience)
    {
        var valueAmount = (playerExperience.CurrrentExp) / (playerExperience.LevelPlayer.Levels[playerExperience.CurrentLevel]);
        _title.SetText( playerExperience.CurrentLevel.ToString());
        _exp.fillAmount = valueAmount;
        
    }
    private void OnDestroy()
    {
        playerManager.PlayerExperience.StateChange -= UpdateExperience;
    }
}
