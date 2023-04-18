using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource MenuMusic1;
    public AudioSource MenuMusic2;
    public AudioSource InRound1;
    public AudioSource InRound2;
    public AudioSource InRound3;
    public AudioSource OutRound1;
    public AudioSource OutRound2;
    public AudioSource OutRound3;
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
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FirstLoadingScreen"))
        {
            
            if(NumberOfSong == 1)
            {
                MenuMusic1.enabled = true;
            }
            else if(NumberOfSong == 2)
            {
                MenuMusic2.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (NumberOfSong == 1)
            {
                MenuMusic1.enabled = true;
            }
            else if (NumberOfSong == 2)
            {
                MenuMusic2.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TestPickUp"))
        {
            if (check1 == false)
            {
                MenuMusic1.enabled = false;
                MenuMusic2.enabled = false;
                Randomizer(1, 3);
                check1 = true;
            }

            if(NumberOfSong == 1)
            {
                MenuMusic1.enabled = true;
            }
            else if(NumberOfSong == 2)
            {
                MenuMusic2.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainGameplayScene"))
        {
            MenuMusic1.enabled = false;
            MenuMusic2.enabled = false;
            
            if(inRound == false)
            {
                InRound1.enabled = false;
                InRound2.enabled = false;
                InRound3.enabled = false;

                if (check2 == false)
                {
                    Randomizer(1, 4);

                    check2 = true;
                    check1 = false;
                }

                if (NumberOfSong == 1)
                {
                    OutRound1.enabled = true;
                }
                else if (NumberOfSong == 2)
                {
                    OutRound2.enabled = true;
                }
                else if (NumberOfSong == 3)
                {
                    OutRound3.enabled = true;
                }
            }

            if(inRound == true)
            {
                OutRound1.enabled = false;
                OutRound2.enabled = false;
                OutRound2.enabled = false;

                if (NumberOfSong == 1)
                {
                    InRound1.enabled = true;
                }
                else if(NumberOfSong == 2)
                {
                    InRound2.enabled = true;
                }
                else if(NumberOfSong == 3)
                {
                    InRound3.enabled = true;
                }
            }
        }

        if(leave == true)
        {
            Randomizer(1, 3);
            leave = false;

            OutRound1.enabled = false;
            OutRound2.enabled = false;
            OutRound3.enabled = false;

            InRound1.enabled = false;
            InRound2.enabled = false;
            InRound3.enabled = false;

            check2 = false;
        }
    }

    public void Randomizer(int min, int max)
    {
        NumberOfSong = Random.Range(min, max);
    }

}
