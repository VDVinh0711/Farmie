

using UnityEngine;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    [SerializeField] private SoundGameManager _soundManager;

    [SerializeField] private GameMultiLang _gameMultiLang;
    
    public SoundGameManager SoundGameManager => _soundManager;
    public GameMultiLang GameMultiLang => _gameMultiLang;


    public override void Awake()
    {
        base.Awake();
        _soundManager = transform.GetComponentInChildren<SoundGameManager>();
        _gameMultiLang = transform.GetComponentInChildren<GameMultiLang>();
    }

    public void StartNewGame()
    {
       
    }

    public void Resumgame()
    {
        EventManager.RaisEvent("LoadData");
    }
    
}
