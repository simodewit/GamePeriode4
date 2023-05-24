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
    public int questIndex;
    public RaycastHit hit;

    private void Start()
    {
        checkPointIndex = 0;
        checkPoints[0] = GameObject.Find("StopPoint");
        checkPoints[1] = GameObject.Find("TheEnd");
        checkPoints[2] = GameObject.Find("EndEnd");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, checkPoints[checkPointIndex].transform.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, checkPoints[checkPointIndex].transform.position) <= distanceToCheckPoint)
        {
            checkPointIndex++;
            
            if(checkPointIndex >= questObjects.Length + 2)
            {
                Destroy(this.gameObject);
            }

            if (checkPoints[1])
            {
                speed = 0f;
                RandomizerQuest();
            }
           
        }            
    }
    public void RandomizerQuest()
    {
        questIndex = Random.Range(1, 4);
        
        if(questIndex == 1)
        {
            StartCoroutine(StartQuest1());
        }
        if (questIndex == 2)
        {
            StartCoroutine(StartQuest2());
        }
        if (questIndex == 3)
        {
            StartCoroutine(StartQuest3());
        }
    }

    
    IEnumerator StartQuest1()
    {
        Debug.Log("Quest 1 started");
        yield return new WaitForSeconds(2);
        EndQuest();
               
    }
    IEnumerator StartQuest2()
    {
        Debug.Log("Quest 2 started");
        yield return new WaitForSeconds(2);
        EndQuest();
        
    }
    IEnumerator StartQuest3()
    {
        Debug.Log("Quest 3 started");
        yield return new WaitForSeconds(2);
        EndQuest();
        
    }

    public void EndQuest()
    {
        speed = 3f;
        checkPointIndex++;
    }

}
