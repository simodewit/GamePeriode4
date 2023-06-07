using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    #region variables

    //all songs
    public AudioSource mainSong;
    public AudioSource lobbyMusic1;
    public AudioSource lobbyMusic2;
    public AudioSource lobbyMusic3;
    public AudioSource inRound1;
    public AudioSource inRound2;
    public AudioSource inRound3;
    public AudioSource outRound1;
    public AudioSource outRound2;
    public AudioSource outRound3;

    //checks
    private int numberOfSong;
    private int checksToTriggerOnce;
    public bool inRound;
    private bool canRandomize;

    //SceneNames
    public string sceneMainMenu;
    public string sceneLobby;
    public string sceneMainGame;

    #endregion

    #region songplayer

    public void Start()
    {
        DontDestroyOnLoad(this);
        mainSong.enabled = true;
        checksToTriggerOnce = 0;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(sceneMainMenu))
        {
            if (checksToTriggerOnce == 1)
            {
                ResetAllSongs();
                mainSong.enabled = true;
            }

            checksToTriggerOnce = 2;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(sceneLobby))
        {
            if (checksToTriggerOnce != 2)
                return;

            checksToTriggerOnce = 3;
            ResetAllSongs();
            Randomizer(1, 4);

            if (numberOfSong == 1)
                lobbyMusic1.enabled = true;

            if (numberOfSong == 2)
                lobbyMusic2.enabled = true;

            if (numberOfSong == 3)
                lobbyMusic3.enabled = true;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(sceneMainGame))
        {
            if (checksToTriggerOnce == 3)
            {
                checksToTriggerOnce = 1;
            }

            if (!inRound)
            {
                if (canRandomize)
                {
                    Randomizer(1, 4);
                    ResetAllSongs();
                    canRandomize = false;
                }

                if (numberOfSong == 1)
                    inRound1.enabled = true;

                if (numberOfSong == 2)
                    inRound2.enabled = true;

                if (numberOfSong == 3)
                    inRound3.enabled = true;
            }
            if (inRound)
            {
                if (!canRandomize)
                {
                    Randomizer(1, 4);
                    ResetAllSongs();
                    canRandomize = true;
                }

                if (numberOfSong == 1)
                    outRound1.enabled = true;

                if (numberOfSong == 2)
                    outRound2.enabled = true;

                if (numberOfSong == 3)
                    outRound3.enabled = true;
            }
        }
    }

    #endregion

    #region randomizer

    public void Randomizer(int min, int max)
    {
        numberOfSong = Random.Range(min, max);
    }

    #endregion

    #region reset

    public void ResetAllSongs()
    {
        mainSong.enabled = false;
        lobbyMusic1.enabled = false;
        lobbyMusic2.enabled = false;
        lobbyMusic3.enabled = false;
        inRound1.enabled = false;
        inRound2.enabled = false;
        inRound3.enabled = false;
        outRound1.enabled = false;
        outRound2.enabled = false;
        outRound3.enabled = false;
    }

    #endregion
}
