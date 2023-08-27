using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMoverments : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementspeed;
    [SerializeField] float jumpforce;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;    // Start is called before the first frame update
    [SerializeField] AudioSource jumpSound;    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementspeed = 6f;
         jumpforce = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalIn = Input.GetAxis("Horizontal");
        float VerticalIn = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(VerticalIn * movementspeed, rb.velocity.y, horizontalIn * movementspeed);
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump(); 
        }
      
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);
        jumpSound.Play();
    }

    bool IsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
