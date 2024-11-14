using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [Header("Movement")]

  public float moveSpeed;
    [Header("Ground Check")]
    public float groundDrag;
  public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    
  public Transform orientation;
  float horizontalInput;
  float verticalInput;

  Vector3 moveDirection;

  Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
 void Update()
    {
        MyInput();
        SpeedControl();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f +0.2f, whatIsGround);

        if (grounded)
        {
            rb.drag = groundDrag;
        }else
        {
            rb.drag = 0;
        }
    }
    private void FixedUpdate(){
        MovePlayer();
    }
    // Update is called once per frame
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        // calculate movement direction, ensure moving to the direction player is looking
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed *10f, ForceMode.Force);
    }
   private void SpeedControl(){
    Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    if(flatVel.magnitude > moveSpeed)
    {
        Vector3 limitedVel = flatVel.normalized *moveSpeed;
        rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
    }
   }
}
