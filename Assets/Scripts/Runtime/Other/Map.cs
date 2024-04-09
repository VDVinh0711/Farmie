
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private string _nameMap;
    [SerializeField] private ChoseMapManager _choseMapManager;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(_nameMap);
    }
}
