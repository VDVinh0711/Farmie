
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConector : MonoBehaviourPunCallbacks
{
    
    /*public static PhotonConector Instance;
    [SerializeField] private RoomSever _roomSever;


    private void Awake()
    {
        Instance = this;
        Debug.Log(" started");
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
       print("Conect master");
       _roomSever.CreatRoomSever();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    
        

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }*/
}
