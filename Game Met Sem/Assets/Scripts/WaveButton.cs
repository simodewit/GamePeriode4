using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveButton : MonoBehaviour
{
    public bool inWave;
    public WaveSpawner waveSpawner;

    public void OnClickButton()
    {
        inWave = true;
        waveSpawner.OnClickExitBuildMode();
    }

    public void Update()
    {
        if(inWave)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
