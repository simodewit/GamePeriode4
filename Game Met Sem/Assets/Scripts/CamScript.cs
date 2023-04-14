using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    private Vector3 halfWidth;
    public GameObject sideAxis;
    public Quaternion camRotation;
    public void CameraDistance(float width)
    {
        width -= 0.5f;
        halfWidth.x = width * 0.5f;
        halfWidth.z = width * 0.5f;
        halfWidth.y += 0.5f;
        sideAxis.transform.position += halfWidth;
        sideAxis.transform.rotation = camRotation;
    }
}
