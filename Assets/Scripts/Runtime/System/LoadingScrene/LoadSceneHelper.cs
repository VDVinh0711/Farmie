
using System;
using System.Collections;
using Farm.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneHelper : MonoBehaviour
{
    [SerializeField] private Fade _loadScene;
    private void Start()
    {
       _loadScene.LoadEnd();
    }
    public void StarLoadSceneCouroutine(string sceneLoad)
    { 
        _loadScene.begin();
        StartCoroutine(LoadScene(sceneLoad));
    }
    private IEnumerator LoadScene(string nameSceneLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameSceneLoad);
        _loadScene.SetActiveLoad();
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            _loadScene.SetValueSlider(progress);
            yield return null;
        }
    }
      
}
