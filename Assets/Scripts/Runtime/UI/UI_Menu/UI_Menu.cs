
using System.IO;

using UnityEngine;

using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    [SerializeField] private Button _btn_StartGame;
    [SerializeField] private Button _btn_SettingGame;
    [SerializeField] private Button _btn_ExitGame;
    [SerializeField] private Button _btn_Resume;
    [SerializeField] private Transform _uiSetting;

    private void Start()
    {
        Getcomponent();
        RegisterEvent();
        SetUpMenu();
    }

    private void StartGame()
    {
        EventManager.RemoveListener("SetupGame",GameManager.Instance.Resumgame);
        EventManager.RegisterEvent("SetupGame",GameManager.Instance.StartNewGame);
        LoadSceneHelper loadSceneHelper = FindObjectOfType<LoadSceneHelper>();
        loadSceneHelper.StarLoadSceneCouroutine("FarmScene");
    }

    private void SettingGame()
    {
        GameManager.Instance.SoundGameManager.PlayMussicSFXsound("Click");
        var uiSetting = _uiSetting.gameObject.GetComponent<UI_Setting>();
        uiSetting.ShowPanelSetting();
    }

    private void ExitGame()
    {
        GameManager.Instance.SoundGameManager.PlayMussicSFXsound("Click");
    }

    private void ResumeGame()
    { 
        GameManager.Instance.SoundGameManager.PlayMussicSFXsound("Click");
        EventManager.RemoveListener("SetupGame",GameManager.Instance.StartNewGame);
        EventManager.RegisterEvent("SetupGame",GameManager.Instance.Resumgame);
        LoadSceneHelper loadSceneHelper = FindObjectOfType<LoadSceneHelper>();
        loadSceneHelper.StarLoadSceneCouroutine("FarmScene");
    }
    private void RegisterEvent()
    {
        _btn_StartGame.onClick.AddListener(StartGame);
        _btn_ExitGame.onClick.AddListener(ExitGame);
        _btn_SettingGame.onClick.AddListener(SettingGame);
        _btn_Resume.onClick.AddListener(ResumeGame);
    }

    private void Getcomponent()
    {
        var menubutton = transform.GetChild(0);
        _btn_StartGame = menubutton.GetChild(0).GetComponent<Button>();
        _btn_Resume = menubutton.GetChild(1).GetComponent<Button>();
        _btn_SettingGame = menubutton.GetChild(2).GetComponent<Button>();
        _btn_ExitGame = menubutton.GetChild(3).GetComponent<Button>();
    }
    private void SetUpMenu()
    {
        if (File.Exists(Application.dataPath + "/dataFarm.json"))
        {
            _btn_Resume.gameObject.SetActive(true);
        }
        else
        {
            _btn_Resume.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {  EventManager.RemoveListener("SetupGame",GameManager.Instance.Resumgame);
        EventManager.RemoveListener("SetupGame",GameManager.Instance.StartNewGame);
        UIManager.Destroy();
    }
}
