using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class CubePlacement : MonoBehaviour
{
    public bool isPickedUp = false;
    private Vector3 pickupOffset;

    public Transform grid;
    public float gridSpacing = 10f;
    public Transform holdingPlace;

    public RaycastHit hit;
    public bool foundObjectToPickUp;
    public GameObject hitGameobject;
    

    private void Start()
    {
       
    }
    void Update()
    {
        foundObjectToPickUp = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                foundObjectToPickUp = true;
                if (hit.transform.tag == "Pickup")
                {
                    hitGameobject = hit.transform.gameObject;
                }
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (hitGameobject)
            {
                if (hitGameobject.transform.tag == "Pickup")
                {
                    if ((isPickedUp == false) && (foundObjectToPickUp == true))
                    {
                        isPickedUp = true;
                    }
                    else
                    {
                        if (isPickedUp == true)
                        {
                            hitGameobject.transform.position = holdingPlace.position;
                            hitGameobject.GetComponent<Collider>().GetComponent<Collider>().enabled = true;
                        }
                        isPickedUp = false;
                    }
                }
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(hitGameobject.transform.position, Vector3.down, out hit))
            {
                if (hit.collider.CompareTag("Grid"))
                {
                    Vector3 gridPos = new Vector3(
                        Mathf.Round(hit.point.x / gridSpacing) * gridSpacing,
                        Mathf.Round(hit.point.y + .5f / gridSpacing) * gridSpacing,
                        Mathf.Round(hit.point.z / gridSpacing) * gridSpacing);
                                
                    //hitGameobject.transform.position = new Vector3(hitGameobject.transform.position.x, hitGameobject.transform.position.y + 1, hitGameobject.transform.position.z);    
                    hitGameobject.transform.position = gridPos;
                }
            }

        }

        if (isPickedUp == true)
        {
            hitGameobject.transform.position = holdingPlace.position;
            hitGameobject.transform.rotation = holdingPlace.rotation;   
            hitGameobject.GetComponent<Collider>().GetComponent<Collider>().enabled = false;
        }
    }
}







