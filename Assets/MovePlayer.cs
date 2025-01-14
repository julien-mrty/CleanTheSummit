using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR; // PicoXR namespace

public class MovePlayer : MonoBehaviour
{

    public float moveSpeed = 2.0f; // Movement speed
    Rigidbody rb; //Reference the rigid body attached to the object "PlayerObj" of the object Player
    public Transform orientation; //Attached to the object "Player". Used to store the player's orientation. This follows the movement of the camera


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //GetComponent allow to access to a specific component associated with the game object the script is attached to. Here, a rigbody

    }

    // Update is called once per frame
    void Update()
    {
        // Get touchpad axes (joystick-like input)
        float horizontal = PXR_Input.GetAxis2D(PXR_Input.Controller.RightController, PXR_Input.Axis2D.PrimaryTouchpad).x;
        float vertical = PXR_Input.GetAxis2D(PXR_Input.Controller.RightController, PXR_Input.Axis2D.PrimaryTouchpad).y;

        // Calculate movement direction
        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        // Normalize the movement vector to maintain consistent speed in diagonal directions
        moveDirection = moveDirection.normalized;

        // Apply movement force
        Vector3 force = moveDirection * moveSpeed * Time.deltaTime; // Calculate force
        rb.MovePosition(rb.position + force); // Update position
    }
}