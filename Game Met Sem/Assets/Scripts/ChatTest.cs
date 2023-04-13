using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChatTest : MonoBehaviour
{
    public GameObject grid;
    public Quaternion rotation;
    private Vector3 center;
    private Vector3 height;

    public void Start()
    {
        center.x = grid.GetComponent<GridMaker>().width * 0.5f;
        center.z = grid.GetComponent<GridMaker>().length * 0.5f;
        height.y = center.z;
        height.z = center.z;
        height.x = center.x;
        transform.position = height;
        transform.rotation = rotation;
    }
}