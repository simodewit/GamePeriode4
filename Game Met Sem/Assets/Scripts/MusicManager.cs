using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    public AudioSource MainSong;
    public AudioSource LobbyMusic1;
    public AudioSource LobbyMusic2;
    public AudioSource LobbyMusic3;
    public AudioSource inRound1;
    public AudioSource inRound2;
    public AudioSource inRound3;
    public AudioSource outRound1;
    public AudioSource outRound2;
    public AudioSource outRound3;

    private int NumberOfSong;
    private bool check1;
    private bool check2;
    public bool inRound;
    public bool leave;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            check2 = false;

            MainSong.enabled = true;

            outRound1.enabled = false;
            outRound2.enabled = false;
            outRound3.enabled = false;

            inRound1.enabled = false;
            inRound2.enabled = false;
            inRound3.enabled = false;

            LobbyMusic1.enabled = false;
            LobbyMusic2.enabled = false;
            LobbyMusic3.enabled = false;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LobbyRoom"))
        {
            if (check1 == false)
            {
                MainSong.enabled = false;
                Randomizer(1, 4);
                check1 = true;
            }

            if(NumberOfSong == 1)
            {
                LobbyMusic1.enabled = true;
            }
            else if(NumberOfSong == 2)
            {
                LobbyMusic2.enabled = true;
            }
            else if(NumberOfSong == 3)
            {
                LobbyMusic3.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TestPickUp"))
        {
            check1 = false;

            LobbyMusic1.enabled = false;
            LobbyMusic2.enabled = false;
            LobbyMusic3.enabled = false;
            
            if(inRound == false)
            {
                inRound1.enabled = false;
                inRound2.enabled = false;
                inRound3.enabled = false;

                if (check2 == false)
                {
                    Randomizer(1, 4);

                    check2 = true;
                    check1 = false;
                }

                if (NumberOfSong == 1)
                {
                    outRound1.enabled = true;
                }
                else if (NumberOfSong == 2)
                {
                    outRound2.enabled = true;
                }
                else if (NumberOfSong == 3)
                {
                    outRound3.enabled = true;
                }
            }

            if(inRound == true)
            {
                outRound1.enabled = false;
                outRound2.enabled = false;
                outRound2.enabled = false;

                if (NumberOfSong == 1)
                {
                    inRound1.enabled = true;
                }
                else if(NumberOfSong == 2)
                {
                    inRound2.enabled = true;
                }
                else if(NumberOfSong == 3)
                {
                    inRound3.enabled = true;
                }
            }
        }
    }

    public void Randomizer(int min, int max)
    {
        NumberOfSong = Random.Range(min, max);
    }
}
