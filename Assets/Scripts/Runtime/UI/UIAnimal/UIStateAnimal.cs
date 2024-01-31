
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStateAnimal : MonoBehaviour
{
    [Header("Ui State")] 
    [SerializeField] private Image _uiHarvest;
    [SerializeField] private Image _uiHurry;
    [SerializeField] private Image _uiSick;
    [SerializeField] private Animal _animal;

    private void Start()
    {
        _animal.PhysiologicalState.ChangeStateAnimal += UpdateStateUiAnimal;
        UpdateStateUiAnimal(_animal.PhysiologicalState);
    }

    public void UpdateStateUiAnimal(PhysiologicalState physiologicalState)
    {
        _uiHarvest.enabled = physiologicalState.IsHarvest;
        _uiHurry.enabled = physiologicalState.IsHurry;
        _uiSick.enabled = physiologicalState.IsSick;
    }
    public void ShowUiHarvest()
    {
        _uiHarvest.gameObject.SetActive(true);
    }
    public void HideUiHarvest()
    {
        _uiHarvest.gameObject.SetActive(false);
    }
    public void ShowUiSick()
    {
        _uiHarvest.gameObject.SetActive(true);
    }
    public void HideUiSick()
    {
        _uiHarvest.gameObject.SetActive(false);
    }
    public void ShowUIHurry()
    {
        _uiHarvest.gameObject.SetActive(true);
    }
    public void HideUiHurryt()
    {
        _uiHarvest.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _animal.PhysiologicalState.ChangeStateAnimal += UpdateStateUiAnimal;
    }
}
