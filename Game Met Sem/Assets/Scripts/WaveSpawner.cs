using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    private bool buildingMode = true;
    private int waveIndex;
    private Wave currentWave;
    public Transform spawnpoint;
    private bool finishedSpawning;
    public WaveButton waveButton;

    [System.Serializable]

    public class Wave
    {
        public GameObject objectToSpawn; 
        public int count;
        public float timeUntilNextSpawn; 
    }
   

    IEnumerator ServeMode(int index)
    {
        if (buildingMode == false)
        {
            if(finishedSpawning == false)
            {
                buildingMode = true;
                StartCoroutine(SpawnObject(index));
                yield break;
            }
        }
    }

    public void RandomTimeBetweenSpawns()
    {
        waves[waveIndex].timeUntilNextSpawn = Random.Range(5f, 20f);
        Debug.Log(waves[waveIndex].timeUntilNextSpawn);
    }

   
    public void OnClickExitBuildMode()
    {
        buildingMode = false;
        StartCoroutine(ServeMode(waveIndex));
    }

    IEnumerator SpawnObject(int index)
    {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++)            
        {
            Instantiate(currentWave.objectToSpawn, spawnpoint.position, Quaternion.identity);

            Debug.Log("Spawned A Truck!");    
            
            if(i == currentWave.count -1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }
            RandomTimeBetweenSpawns();
            yield return new WaitForSeconds(currentWave.timeUntilNextSpawn); 
        }
       
    }

    public void Update()
    {

        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Truck").Length == 0)
        {
            finishedSpawning = false;
            if(waveIndex + 1 < waves.Length)
            {
                waveButton.inWave = false;
                waveIndex++;
                StartCoroutine(ServeMode(waveIndex));
                
                Debug.Log("NextWave");                
            }
            else
            {
                Debug.Log("GAME FINISHED");
            }
        }
    }
}
