using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaveSpawnerScript : MonoBehaviour
{
    public Information[] info;

    private bool IsTriggered;
    public GameObject button;
    public float timer;
    private int waveCounter;
    public GameObject truck;
    public GameObject place3;
    public int truckBuildUp;
    private int currentSpawnedTrucks;
    private List<GameObject> trucksInGame;
    private GameObject newTruck;

    public void Start()
    {
        timer = info[waveCounter].time;
    }

    public void Update()
    {
        Timer();
        TruckSpawner();
        EndWave();
    }

    public void Timer()
    {
        if (!IsTriggered)
            return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        
        if(currentSpawnedTrucks + truckBuildUp == info[waveCounter].trucks)
        {
            timer = 0;
            return;
        }
            
        timer = info[waveCounter].time;
        truckBuildUp += 1;
    }

    public void TruckSpawner()
    {
        if (place3.GetComponent<OcuppiedTruck>().occupied)
            return;

        if (truckBuildUp < 1)
            return;

        currentSpawnedTrucks += 1;
        truckBuildUp -= 1;
        newTruck = Instantiate(truck, transform.position, Quaternion.identity);
        trucksInGame.Add(newTruck);
    }

    public void EndWave()
    {
        if(info[waveCounter].trucks != currentSpawnedTrucks)
            return;

        if (trucksInGame.Count != 0)
            return;

        IsTriggered = false;
        button.SetActive(true);
        waveCounter += 1;
    }

    public void OnClickButton()
    {
        IsTriggered = true;
        button.SetActive(false);
    }
}

[Serializable]
public class Information
{
    public float time;
    public int trucks;
}
