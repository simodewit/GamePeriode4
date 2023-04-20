using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject objectToSpawn; 
        public int count;   
        public float timeBetweenSpawns;    
    }

    public Wave[] waves;
    private bool buildingMode = true;
    private int waveIndex;
    private bool isSpawning;
    private float timeUntilNextSpawn;
    public Transform spawnpoint;

    private void Start()
    {
        if (buildingMode == false)
        {
            SpawnWaves();
        }
    }

    private void Update()
    {
        if (isSpawning == true)
        {
            if (timeUntilNextSpawn <= 0)
            {
                SpawnObject();
                timeUntilNextSpawn = waves[waveIndex].timeBetweenSpawns;
            }
            else
            {
                timeUntilNextSpawn -= Time.deltaTime;
            }

        }
    }

    public void OnClickExitBuildMode()
    {
        buildingMode = false;
    }

    public void SpawnWaves()
    {
        isSpawning = true;
    }

    public void SpawnObject()
    {
        //waves[waveIndex].objectToSpawn = Instantiate(waves[waveIndex].objectToSpawn.transform.position, spawnpoint.position, Quaternion.identity);
    }



}
