using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [Header("Movement")]

  public float moveSpeed;
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
   
}