
using UnityEngine;
using UnityEngine.EventSystems;


public class Map : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private string _nameMap;
    [SerializeField] private ChoseMapManager _choseMapManager;
    public void OnPointerClick(PointerEventData eventData)
    {
       _choseMapManager.loadMapChosing(_nameMap);
    }
}
