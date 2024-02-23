
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UI_Mainmenu : MonoBehaviour,IAnimationUI
{
    [SerializeField] private Button _btn_StartGame;
    [SerializeField] private Button _btn_SettingGame;
    [SerializeField] private Button _btn_ExitGame;
   
    [SerializeField] private UI_Menu_Manager _uiMenuManager;

    private void Start()
    {
        RegisterEvent();
    }

    private void StartGame()
    {
        _uiMenuManager.OpenUiMenuGame(_uiMenuManager.UI_Login.transform);
        /*LoadSceneHelper loadSceneHelper = FindObjectOfType<LoadSceneHelper>();
        loadSceneHelper.StarLoadSceneCouroutine("FarmScene");*/
    }

    private void SettingGame()
    {
        GameManager.Instance.SoundGameManager.PlayMussicSFXsound("Click");
        _uiMenuManager.OpenUiMenuGame(_uiMenuManager.UI_Setting.transform);
      
    }

    private void ExitGame()
    {
        GameManager.Instance.SoundGameManager.PlayMussicSFXsound("Click");
    }
    private void RegisterEvent()
    {
        _btn_StartGame.onClick.AddListener(StartGame);
        _btn_ExitGame.onClick.AddListener(ExitGame);
        _btn_SettingGame.onClick.AddListener(SettingGame);
    }
    private void OnDestroy()
    {  EventManager.RemoveListener("SetupGame",GameManager.Instance.Resumgame);
        EventManager.RemoveListener("SetupGame",GameManager.Instance.StartNewGame);
        UIManager.Destroy();
    }
    public void AnimationIn()
    {
     
        _btn_StartGame.gameObject.GetComponent<RectTransform>().DOMove(new Vector3(0 , 0,0),1);
        _btn_SettingGame.gameObject.GetComponent<RectTransform>().DOMove(new Vector3(0 , -1,0),2);
        _btn_ExitGame.gameObject.GetComponent<RectTransform>().DOMove(new Vector3(0 , -2,0),3);
    }

    public void AnimationOut()
    {
        _btn_StartGame.gameObject.GetComponent<RectTransform>().DOMove(new Vector3(-20 , 0,0),1);
        _btn_SettingGame.gameObject.GetComponent<RectTransform>().DOMove(new Vector3(-20 , -1,0),2);
        _btn_ExitGame.gameObject.GetComponent<RectTransform>().DOMove(new Vector3(-20 , -2,0),3);
    }

}
