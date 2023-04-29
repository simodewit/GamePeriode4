using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 movement;
    public Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;
    private Quaternion look;
    private PhotonView view;
    private Vector3 gravity;
    public float gravitySpeed;
    public Vector3 lookRotation;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    public void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        lookRotation = movement;
    }

    public void FixedUpdate()
    {
        if (view.IsMine)

        gravity = Physics.gravity.normalized * gravitySpeed;
        movement += gravity;
        rb.velocity = movement * moveSpeed;

        if (movement != Vector3.zero)
        {
            look = Quaternion.LookRotation(lookRotation, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, look, rotateSpeed);
        }
    }
}
