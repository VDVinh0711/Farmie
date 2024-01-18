
using System.Collections;

using Farm.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper :MonoBehaviour
{
    [SerializeField] private Fade _loadScene;
    
    public void StarLoadSceneCouroutine(string sceneLoad)
    { 
        StartCoroutine(LoadSceneSyc(sceneLoad));
    }
    private IEnumerator LoadSceneSyc(string nameSceneLoad)
    {
        
        DontDestroyOnLoad(gameObject);
        var _currentScene = SceneManager.GetActiveScene();
        print(_currentScene.name);
        _loadScene = FindObjectOfType<Fade>();
        _loadScene.ShowLoadingScene();
        var asyncLoad = SceneManager.LoadSceneAsync(nameSceneLoad, LoadSceneMode.Additive);
        _loadScene.SetValueBar(asyncLoad.progress); 
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            var progress = Mathf.Clamp01(asyncLoad.progress / .9f);
            _loadScene.SetValueBar(asyncLoad.progress);
            if (Mathf.Approximately(asyncLoad.progress, 0.9f))
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        SceneManager.UnloadSceneAsync(_currentScene);
        _loadScene.HideLoadingScene();
        EventManager.RaisEvent("SetupGame");
        Destroy(gameObject);
       
    }
      
}
