using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    public AudioSource menuMusic1;
    public AudioSource menuMusic2;
    public AudioSource inRound1;
    public AudioSource inRound2;
    public AudioSource inRound3;
    public AudioSource outRound1;
    public AudioSource outRound2;
    public AudioSource outRound3;
    public AudioSource buttonClick;

    public int NumberOfSong;
    public bool check1;
    public bool check2;
    public bool inRound;
    public bool leave;

    void Start()
    {
        DontDestroyOnLoad(this);
        Randomizer(1, 3);
    }
    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FirstLoadingScreen"))
        {
            if(NumberOfSong == 1)
            {
                menuMusic1.enabled = true;
            }
            else if(NumberOfSong == 2)
            {
                menuMusic2.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (NumberOfSong == 1)
            {
                menuMusic1.enabled = true;
            }
            else if (NumberOfSong == 2)
            {
                menuMusic2.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LobbyRoom"))
        {
            if (check1 == false)
            {
                menuMusic1.enabled = false;
                menuMusic2.enabled = false;
                Randomizer(1, 3);
                check1 = true;
            }

            if(NumberOfSong == 1)
            {
                menuMusic1.enabled = true;
            }
            else if(NumberOfSong == 2)
            {
                menuMusic2.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TestPickUp"))
        {
            menuMusic1.enabled = false;
            menuMusic2.enabled = false;
            
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

        if(leave == true)
        {
            Randomizer(1, 3);
            leave = false;

            outRound1.enabled = false;
            outRound2.enabled = false;
            outRound3.enabled = false;

            inRound1.enabled = false;
            inRound2.enabled = false;
            inRound3.enabled = false;

            check2 = false;
        }
    }

    public void Randomizer(int min, int max)
    {
        NumberOfSong = Random.Range(min, max);
    }

    public void SoundEffect()
    {
        if(buttonClick.enabled == true)
        {
            buttonClick.Play();
        }
        else
        {
            buttonClick.enabled = true;
        }
    }
}
