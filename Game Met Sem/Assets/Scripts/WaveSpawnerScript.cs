using Photon.Pun;
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
    public List<GameObject> trucksInGame;
    private GameObject newTruck;
    public PhotonView view;

    public void Start()
    {
        view = GetComponent<PhotonView>();
        trucksInGame = new List<GameObject>();
        timer = info[waveCounter].time;
    }

    public void Update()
    {
        view.RPC("Timer", RpcTarget.All);
        view.RPC("TruckSpawner", RpcTarget.All);
        view.RPC("EndWave", RpcTarget.All);
    }

    [PunRPC]
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

    [PunRPC]
    public void TruckSpawner()
    {
        if (place3.GetComponent<OcuppiedTruck>().occupied)
            return;

        if (truckBuildUp < 1)
            return;

        currentSpawnedTrucks += 1;
        truckBuildUp -= 1;
        newTruck = PhotonNetwork.Instantiate("truck", transform.position, new Quaternion (0,180,0,0));
        trucksInGame.Add(newTruck);
        print(trucksInGame.Count);
    }

    [PunRPC]
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
