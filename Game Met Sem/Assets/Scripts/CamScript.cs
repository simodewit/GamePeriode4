using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject grid;
    public float width;
    public Vector3 camPositionX;

    public void Start()
    {
        width = grid.GetComponent<GridMaker>().width;
        camPositionX.x = width * 0.5f;
        transform.position = camPositionX;
    }
}
