using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public TMP_Text roomsName;
    public RoomManager roomManager;

    // Update is called once per frame
    void Update()
    {
        roomsName.text = roomManager.roomName.text;
    }
}
