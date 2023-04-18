using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SingleAndMultiManager : MonoBehaviourPunCallbacks
{
   public void OnClickSingle()
    {
        SceneManager.LoadScene("LobbyRoom");
    }

    public void OnClickMulti()
    {
        SceneManager.LoadScene("RoomMaking");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MainMenu");

    }
   
}
