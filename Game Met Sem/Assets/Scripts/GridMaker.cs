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

    private Vector3 halfWidth;
    public GameObject sideAxis;
    public Quaternion camRotation;
    public float ajustHeight;

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
        CameraDistance(width);
    }

    public void CameraDistance(float width)
    {
        width -= 0.5f;
        halfWidth.x = width * 0.5f;
        halfWidth.z = width * ajustHeight;
        halfWidth.y += 0.5f;
        sideAxis.transform.position += halfWidth;
        sideAxis.transform.rotation = camRotation;
    }
}
