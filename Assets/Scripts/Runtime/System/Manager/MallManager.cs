using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MallManager : MonoBehaviour
{
    [SerializeField] private Transform _playerPre;
    
    void Start()
    {
        PhotonNetwork.Instantiate(_playerPre.name, new Vector3(0, 0, 0), Quaternion.identity);
    }

   
   
}
