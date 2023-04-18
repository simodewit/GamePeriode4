using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource mainMenuMusic1;
    public AudioSource playBuildModeMusic1;
    public AudioSource playBuildModeMusic2;
    public GameObject PlayBuildMusic1;
    public int NumberOfSong;
    public bool check;

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
                mainMenuMusic1.enabled = true;
            }
            else if(NumberOfSong == 2)
            {
                //simon music
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (NumberOfSong == 1)
            {
                mainMenuMusic1.enabled = true;
            }
            else if (NumberOfSong == 2)
            {
                //simon music
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TestPickUp"))
        {
            if(check == false)
            {
                Randomizer(1, 3);
                check = true;
            }

            mainMenuMusic1.enabled = false;

            if (NumberOfSong == 1)
            {
                playBuildModeMusic1.enabled = true;

            }
            else if (NumberOfSong == 2)
            {
                playBuildModeMusic2.enabled = true;
            }
        }
    }

    public void Randomizer(int min, int max)
    {
        NumberOfSong = Random.Range(min, max);
    }

}
