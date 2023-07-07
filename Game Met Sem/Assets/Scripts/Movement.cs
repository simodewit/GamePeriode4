using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region variables

    private Vector3 movement;
    public Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;
    private Quaternion look;
    private PhotonView view;
    private Vector3 gravity;
    public float gravitySpeed;
    public Vector3 lookRotation;
    public bool onGround;
    private Vector3 snapDing;
    public ParticleSystem runStofWolk;
    private bool isRunning;

    public Animator anim;


    #endregion

    #region main code

    private void Start()
    {
        view = GetComponent<PhotonView>();
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        lookRotation.x = movement.x;
        lookRotation.z = movement.z;

        if(transform.position.y <= -5f)
        {
            transform.position = new Vector3(10, 2, 1);
        }

        if (view.IsMine)
        {
            if (movement.x != 0 || movement.z != 0)
            {
                view.RPC("WalkParticles", RpcTarget.All);
            }
            else if (movement.x == 0 || movement.z == 0)
            {
                view.RPC("WalkParticles", RpcTarget.All);
            }
        }
    }

    public void FixedUpdate()
    {
        if (!view.IsMine)
            return;

        if (!onGround)
        {
            gravity = Physics.gravity.normalized * gravitySpeed;
            movement += gravity;
        }
        else
        {
            movement.y = 0;
        }

        rb.velocity = movement * moveSpeed;

        if (lookRotation != Vector3.zero)
        {
            look = Quaternion.LookRotation(lookRotation, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, look, rotateSpeed);
        }

    }

    [PunRPC]
    public void WalkParticles()
    {
        if (movement.x != 0 || movement.z != 0)
        {
            anim.SetBool("New Bool", true);
            runStofWolk.gameObject.SetActive(true);
        }
        else if (movement.x == 0 || movement.z == 0)
        {
            anim.SetBool("New Bool", false);
            runStofWolk.gameObject.SetActive(false);
        }
    }

    #endregion

    #region collisioncheck

    public void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    #endregion
}
