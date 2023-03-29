using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public float width;
    public float length;
    public GameObject node;
    private Vector3 placePosition;
    public quaternion rotation;
    public Camera mainCam;
    private Vector3 lookPosition;
    private Vector3 camPosition;

    private void Start()
    {
        for(int i = 0; i < width; i++)
        {

            for( int j = 0; j < length; j++)
            {
                placePosition.x = i + transform.position.x;
                placePosition.z = j + transform.position.z;
                placePosition.y = transform.position.y;

                var nodeToParrent = Instantiate(node, placePosition, rotation);
                nodeToParrent.transform.parent = transform;
                nodeToParrent.GetComponent<Node>().length = j;
                nodeToParrent.GetComponent<Node>().witdh = i;
            }
        }
    }
}
