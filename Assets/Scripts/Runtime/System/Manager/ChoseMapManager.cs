
using UnityEngine;


public class ChoseMapManager : MonoBehaviour
{
   [SerializeField]  private LoadSceneHelper _loadSceneHelper;
    public void loadMapChosing(string nameMap)
    {
        _loadSceneHelper.StarLoadSceneCouroutine(nameMap);
    }
}
