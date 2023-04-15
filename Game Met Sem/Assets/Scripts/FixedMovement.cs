using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovement : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 movement;
    public float moveSpeed;
    public void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        rb.AddForce(movement.normalized * moveSpeed * Time.deltaTime, ForceMode.Force);
    }
}
