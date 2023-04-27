using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAI : MonoBehaviour
{
    public int checkPointIndex;

    public GameObject[] checkPoints;
    public GameObject[] questObjects;
    public float speed;
    public float distanceToCheckPoint;
    private int questIndex;

    private void Start()
    {
        checkPointIndex = 0;
        checkPoints[0] = GameObject.Find("StopPoint");
        checkPoints[1] = GameObject.Find("TheEnd");
        checkPoints[2] = GameObject.Find("EndEnd");
        questObjects[0] = GameObject.Find("InfinityObject");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, checkPoints[checkPointIndex].transform.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, checkPoints[checkPointIndex].transform.position) <= distanceToCheckPoint)
        {
            checkPointIndex++;
            RandomizerQuest();
        }            
    }
    public void RandomizerQuest()
    {
        questIndex = Random.Range(0, 4);
        
        if(questIndex == 1)
        {
            StartQuest1();
        }
        if (questIndex == 2)
        {
            StartQuest2();
        }
        if (questIndex == 3)
        {
            StartQuest3();
        }
    }

    public void StartQuest1()
    {
        EndQuest();
        Debug.Log("Quest 1 started");        
    }

    public void StartQuest2()
    {
        EndQuest();
        Debug.Log("Quest 2 started");
    }

    public void StartQuest3()
    {
        EndQuest();
        Debug.Log("Quest 3 started");
    }

    public void EndQuest()
    {
        speed = 3f;
    }

}
