using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Test : MonoBehaviourPun
{
    [PunRPC]
    private RaycastHit hit;
    private RaycastHit hit1;
    private RaycastHit hit2;
    private RaycastHit hit3;
    private bool pickedUpSomething;
    public GameObject empty;
    private bool check;
    private Vector3 placePosition;
    public float radius;
    private bool blueprint;
    public Vector3 blueprintPlacePosition;
    public Quaternion blueprintRotation;
    public PhotonView view;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void Update()
    {
        if (view.IsMine)
        {
            photonView.RPC("DoeDingen", RpcTarget.All);
        }
    }

    [PunRPC]

    public void DoeDingen()
    {
        check = true;
        if (Input.GetButtonDown("Fire1"))
        {
            print("1");
            if (pickedUpSomething == true)
            {
                print("2");
                if (Physics.Raycast(empty.transform.position, -empty.transform.up, out hit1, 5))
                {
                    print("3");
                    if (hit1.transform.GetComponent<Node>().occupied == false)
                    {
                        print("4");
                        if (blueprint == true)
                        {
                            hit.transform.parent = null;
                            placePosition = hit1.transform.position;
                            placePosition += blueprintPlacePosition;
                            hit.transform.position = placePosition;
                            hit.transform.localScale = new Vector3(1, 1, 1);
                            hit.collider.enabled = true;
                            pickedUpSomething = false;
                            check = false;
                            hit.transform.localRotation = blueprintRotation;
                            hit1.transform.GetComponent<Node>().occupied = true;
                            print("5");
                        }
                        else
                        {
                            hit.transform.parent = null;
                            placePosition = hit1.transform.position;
                            placePosition.y += 1;
                            hit.transform.position = placePosition;
                            hit.transform.localScale = new Vector3(1, 1, 1);
                            hit.collider.enabled = true;
                            pickedUpSomething = false;
                            check = false;
                            hit.transform.localRotation = new Quaternion(0, 0, 0, 0);
                            hit1.transform.GetComponent<Node>().occupied = true;
                            print("5");
                        }
                    }
                }
            }

            if (check == true)
            {
                print("11");
                if (pickedUpSomething == false)
                {
                    print("12");
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
                    {
                        print("13");
                        if (hit.transform.tag == "Pickup")
                        {
                            if (Physics.Raycast(empty.transform.position, -empty.transform.up, out hit3, 5))
                            {
                                print("14");
                                hit.collider.enabled = false;
                                pickedUpSomething = true;
                                hit.transform.SetParent(empty.transform);
                                hit.transform.localPosition = new Vector3(0, 0, 0);
                                hit.transform.localRotation = new Quaternion(0, 0, 0, 0);
                                hit.transform.localScale = new Vector3(1, 1, 1);
                                hit3.transform.GetComponent<Node>().occupied = false;
                            }
                        }
                    }
                }
            }

            if (Physics.SphereCast(transform.position, radius, transform.forward, out hit2, 5))
            {
                print("21");
                if (hit2.transform.tag == "Blueprint")
                {
                    print("22");
                    if (pickedUpSomething == false)
                    {
                        print("23");
                        hit.collider.enabled = false;
                        pickedUpSomething = true;
                        hit.transform.SetParent(empty.transform);
                        hit.transform.localPosition = new Vector3(0, 0, 0);
                        hit.transform.localRotation = new Quaternion(0, 0, 0, 0);
                        hit.transform.localScale = new Vector3(1, 1, 1);
                        blueprint = true;
                    }
                }
            }
        }
    }
}
