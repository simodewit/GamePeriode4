using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 movement;
    public float moveSpeed;
    public PhotonView view;
    
    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    public void Update()
    {
        if (view.IsMine)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.z = Input.GetAxis("Vertical");
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

            if (movement != Vector3.zero)
            {
                transform.forward = movement;
            }
        }
    }
}
