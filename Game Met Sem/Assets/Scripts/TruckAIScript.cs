using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TruckAIScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject place1;
    public GameObject place2;
    public GameObject place3;
    public GameObject endPlace;
    private float distance;
    private GameObject currentPlace;
    private bool isDelivered;

    public void Start()
    {
        place1 = GameObject.Find("TheEnd");
        place2 = GameObject.Find("WaitInLine1");
        place3 = GameObject.Find("WaitInLine2");

        agent.destination = place3.transform.position;
        currentPlace = place3;
    }

    public void Update()
    {
        distance = Vector3.Distance(transform.position, agent.destination);

        if(distance > .5f)
            return;

        GetOres();
        WaitPlace1();
        WaitPlace2();
    }

    public void GetOres()
    {
        if(currentPlace != place1)
            return;

        if(isDelivered == false)
            return;

        agent.destination = endPlace.transform.position;
    }

    public void WaitPlace1()
    {
        if (currentPlace != place2)
            return;

        if (place1.GetComponent<OcuppiedTruck>().occupied == true)
            return;

        agent.destination = place1.transform.position;
    }

    public void WaitPlace2()
    {
        if (currentPlace != place3)
            return;

        if (place2.GetComponent<OcuppiedTruck>().occupied == true)
            return;

        agent.destination = place2.transform.position;
    }
}
