using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float walkingSpeed = 2.0f; // Movement speed
    Rigidbody rb; //Reference the rigid body attached to the object "PlayerObj" of the object Player

    Vector3 moveDirection;
    public float horizontalInput;
    public float verticalInput;
    public Transform orientation; //Attached to the object "Player". Used to store the player's orientation. This follows the movement of the camera


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //GetComponent allow to access to a specific component associated with the game object the script is attached to. Here, a rigbody

    }

    // Update is called once per frame
    void Update()
    {
        // Get input axes
        horizontalInput = Input.GetAxisRaw("Horizontal"); //can be -1, 0 or 1 
        verticalInput = Input.GetAxisRaw("Vertical"); //can be -1, 0 or 1 

        // Calculate movement vector
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Move the Rigidbody
        rb.AddForce(moveDirection.normalized * walkingSpeed, ForceMode.Force);
    }
}