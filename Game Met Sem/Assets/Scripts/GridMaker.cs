using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public int width;
    public int length;
    public GameObject node;
    private Vector3 placePosition;
    public quaternion rotation;
    public GameObject cam;

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
        cam.GetComponent<CamScript>().CameraDistance(width);
    }
}
