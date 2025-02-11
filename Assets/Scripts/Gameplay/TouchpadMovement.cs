using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TouchpadMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float groundDetectionDistance = 1.5f; // Distance pour d�tecter le sol
    public LayerMask groundLayer;

    private Transform cameraTransform;
    private InputDevice controller;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // D�sactiver la gravit� (on g�re manuellement la hauteur)
        rb.isKinematic = true; // Emp�cher les forces physiques d�affecter la capsule

        cameraTransform = Camera.main?.transform;

        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, inputDevices);

        if (inputDevices.Count > 0)
        {
            controller = inputDevices[0];
        }
        else
        {
            Debug.LogError("Aucun contr�leur d�tect� !");
        }
    }

    void FixedUpdate()
    {
        AdjustHeightToGround(); // D�tection du sol ex�cut�e � chaque frame physique
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (controller.isValid)
        {
            Vector2 touchpadValue;
            if (controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out touchpadValue))
            {
                Vector3 forward = cameraTransform.forward;
                Vector3 right = cameraTransform.right;

                forward.y = 0;
                right.y = 0;

                forward.Normalize();
                right.Normalize();

                Vector3 direction = forward * touchpadValue.y + right * touchpadValue.x;

                // D�placement horizontal uniquement (X, Z)
                Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

                // **Appliquer la d�tection du sol AVANT de d�placer la capsule**
                newPosition.y = GetGroundHeight(newPosition);

                // D�placer la capsule
                transform.position = newPosition;
            }
        }
    }

    void AdjustHeightToGround()
    {
        // Ajuster la hauteur m�me si le joueur ne bouge pas (ex: mont�e d'ascenseur)
        Vector3 currentPosition = transform.position;
        currentPosition.y = GetGroundHeight(currentPosition);
        transform.position = currentPosition;
    }

    private float GetGroundHeight(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position + Vector3.up * groundDetectionDistance, Vector3.down, out hit, groundDetectionDistance * 2, groundLayer))
        {
            return hit.point.y; // Retourne la hauteur du sol d�tect�
        }
        return transform.position.y; // Si aucun sol d�tect�, garde la hauteur actuelle
    }
}