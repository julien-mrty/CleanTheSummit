using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed = 3.0f;  // Speed of movement

    void Update()
    {
        // Capture D-pad input
        if (Pvr_ControllerManager.controllerlink != null)
        {
            // Check if the D-pad buttons are pressed
            if (Controller.UP) // D-pad Up
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Controller.DOWN) // D-pad Down
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            if (Controller.LEFT) // D-pad Left
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            if (Controller.RIGHT) // D-pad Right
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
    }
}

