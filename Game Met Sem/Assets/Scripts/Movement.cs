using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 movement;
    public float moveSpeed;

    public void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        movement.Normalize();

        if(movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }
}
