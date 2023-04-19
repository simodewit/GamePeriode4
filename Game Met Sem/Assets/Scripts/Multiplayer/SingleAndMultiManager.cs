using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SingleAndMultiManager : MonoBehaviourPunCallbacks
{
    public GameObject manager;

    public void Start()
    {
        manager = GameObject.Find("MainMusicManager");
    }

    public void OnClickSingle()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
        SceneManager.LoadScene("LobbyRoom");
    }

    public void OnClickMulti()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
        SceneManager.LoadScene("RoomMaking");
    }

    public void OnClickBack()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
        SceneManager.LoadScene("MainMenu");
    }
}
