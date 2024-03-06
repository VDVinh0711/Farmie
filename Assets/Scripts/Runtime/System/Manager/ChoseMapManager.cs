using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseMapManager : MonoBehaviour
{
   [SerializeField]  private LoadSceneHelper _loadSceneHelper;
    public void loadMapChosing(string nameMap)
    {
        _loadSceneHelper.StarLoadSceneCouroutine(nameMap);
    }
}
