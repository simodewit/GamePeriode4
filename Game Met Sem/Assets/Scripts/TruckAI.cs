using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.Cockpit;
using UnityEngine;
using UnityEngine.AI;

public class TruckAI : MonoBehaviour
{
    public int checkPointIndex;

    public GameObject[] checkPoints;
    public GameObject[] questObjects;
    public float speed;
    public float distanceToCheckPoint;
    public int questIndex;
    public RaycastHit hit;
    public NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        checkPointIndex = 0;
        checkPoints[0] = GameObject.Find("StopPoint");
        checkPoints[1] = GameObject.Find("TheEnd");
        checkPoints[2] = GameObject.Find("EndEnd");
    }

    private void Update()
    {
        agent.destination = checkPoints[checkPointIndex].transform.position;
        if (Vector3.Distance(transform.position, checkPoints[checkPointIndex].transform.position) <= distanceToCheckPoint)
        {
            if (checkPoints[1])
            {
                speed = 0f;
                RandomizerQuest();
            }       
        }            
    }
    public void RandomizerQuest()
    {
        StartCoroutine(StartQuest1());
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Muur")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StartQuest1()
    {
        Debug.Log("Quest 1 started");
        yield return new WaitForSeconds(5);
        EndQuest();
               
    }

    public void EndQuest()
    {
        speed = 3f;
        checkPointIndex++;
    }

}
