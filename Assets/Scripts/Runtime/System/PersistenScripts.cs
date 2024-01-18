
using UnityEngine;


public class PersistenScripts : MonoBehaviour
{
    [SerializeField] private Transform _persistenObj;
    static bool idSpawn; 
    private void Awake()
    {
        if (!idSpawn)
        {
            var objspawn = Instantiate(_persistenObj);
            DontDestroyOnLoad(objspawn);
            idSpawn = true;
        }
    }
}
