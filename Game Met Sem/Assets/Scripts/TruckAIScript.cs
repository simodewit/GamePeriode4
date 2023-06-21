using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TruckAIScript : MonoBehaviour
{
    public PhotonView view;

    //places where he can stand
    public GameObject place1;
    public GameObject place2;
    public GameObject place3;
    public GameObject endPlace;

    //in script things
    public float distance;
    public GameObject currentPlace;
    public bool isDelivered;

    public float moveSpeed;
    public Vector3 moveDirection;

    public void Start()
    {
        view = transform.GetComponent<PhotonView>();

        if (!view.IsMine)
            return;

        place1 = GameObject.Find("StopPoint");
        place2 = GameObject.Find("WaitInLine1");
        place3 = GameObject.Find("WaitInLine2");
        endPlace = GameObject.Find("TheEnd");

        currentPlace = place3;
        place3.GetComponent<OcuppiedTruck>().occupied = true;
    }

    public void Update()
    {
        if(!view.IsMine)
            return;

        distance = Vector3.Distance(transform.position, currentPlace.transform.position);

        if(distance > 5)
        {
            view.RPC("MoveTruck", RpcTarget.All, moveSpeed = 3);
        }

        if (distance > 2.5)
        {
            if(distance < 5)
                view.RPC("MoveTruck", RpcTarget.All, distance - 1f);
        }


        view.RPC("GetOres",RpcTarget.All);
        view.RPC("WaitPlace1", RpcTarget.All);
        view.RPC("WaitPlace2", RpcTarget.All);
    }

    [PunRPC]
    public void GetOres()
    {
        if(currentPlace != place1)
            return;


        if (isDelivered == false)
            return;

        currentPlace = endPlace;
        place1.GetComponent<OcuppiedTruck>().occupied = false;
    }

    [PunRPC]
    public void WaitPlace1()
    {
        if (currentPlace != place2)
            return;

        if (place1.GetComponent<OcuppiedTruck>().occupied == true)
            return;

        currentPlace = place1;
        place1.GetComponent<OcuppiedTruck>().occupied = true;
        place2.GetComponent<OcuppiedTruck>().occupied = false;
    }

    [PunRPC]
    public void WaitPlace2()
    {
        if (currentPlace != place3)
            return;

        if (place2.GetComponent<OcuppiedTruck>().occupied == true)
            return;

        currentPlace = place2;
        place2.GetComponent<OcuppiedTruck>().occupied = true;
        place3.GetComponent<OcuppiedTruck>().occupied = false;
    }

    [PunRPC]
    public void MoveTruck(float moveSpeed)
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
