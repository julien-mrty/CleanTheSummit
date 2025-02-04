using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovePlayerRig : MonoBehaviour
{
    public float speed = 2.0f;
    private Transform xrRig;
    private Transform cameraTransform;
    private InputDevice controller;
    private Rigidbody rb;

    void Start()
    {
        xrRig = GetComponent<Transform>();
        cameraTransform = Camera.main?.transform;
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing! Please add a Rigidbody to the GameObject.");
        }
        else
        {
            rb.freezeRotation = true; // Prevents unwanted rotations
        }

        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, inputDevices);

        if (inputDevices.Count > 0)
        {
            controller = inputDevices[0];
        }
        else
        {
            Debug.LogError("No valid controller detected.");
        }
    }

    void Update()
    {
        if (controller.isValid && rb != null)
        {
            if (controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 touchpadValue))
            {
                Vector3 forward = cameraTransform.forward;
                Vector3 right = cameraTransform.right;

                forward.y = 0;
                right.y = 0;

                forward.Normalize();
                right.Normalize();

                Vector3 direction = (forward * touchpadValue.y + right * touchpadValue.x).normalized;
                Vector3 movement = direction * speed * Time.deltaTime;

                rb.MovePosition(rb.position + movement);
            }
        }
    }
}
