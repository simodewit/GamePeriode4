using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveButton : MonoBehaviour
{
    public PhotonView view;
    public bool inWave;
    public WaveSpawnerScript waveSpawner;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void OnClickButton()
    {
        view.RPC("Abc", RpcTarget.All);
    }

    public void Abc()
    {
        inWave = true;
        waveSpawner.OnClickButton();
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
