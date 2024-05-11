
using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class RoomSever : MonoBehaviourPunCallbacks
{
    /*private const string nameRoom1 = "Shoppe";
    private const string nameRoom2 = "Lazada";
    private const string nameRoom3 = "TikTokShop";
    private Dictionary<string, string> listRoom = new Dictionary<string, string>()
    {
        { "room1", "Shoppe" },
        { "room2", "Lazada" },
        { "room3", "TiktokShop" }
    };

    public Dictionary<string, string> ListRoom => listRoom;

    

    public void CreatRoomSever()
    {
        foreach (var nameroom in listRoom.Values)
        {
           CreatRoom(nameroom);
        }
    }
    private void CreatRoom(string nameroom)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(nameroom, roomOptions);
    }*/
}
