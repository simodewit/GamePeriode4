using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTruck : MonoBehaviour
{
    public WaveSpawnerScript script;
    public void Start()
    {
        script = GameObject.Find("WaveSpawner").GetComponent<WaveSpawnerScript>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        script.trucksInGame.Remove(collision.gameObject);
        Destroy(collision.gameObject);
    }
}
