using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayersToSpawnpoint : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] players;

    public void Start()
    {
        players[0] = GameObject.Find("Player1");
        players[1] = GameObject.Find("Player1 (1)");
        players[2] = GameObject.Find("Player3");
        players[3] = GameObject.Find("Player4");

        players[0].transform.position = spawnPoints[0].transform.position;
        players[1].transform.position = spawnPoints[1].transform.position;
        players[2].transform.position = spawnPoints[2].transform.position;
        players[3].transform.position = spawnPoints[3].transform.position;
    }
}
