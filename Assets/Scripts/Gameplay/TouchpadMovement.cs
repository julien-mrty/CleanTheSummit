using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TouchpadMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float groundDetectionDistance = 1.5f; // Distance pour détecter le sol
    public LayerMask groundLayer;

    private Transform cameraTransform;
    private InputDevice controller;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Désactiver la gravité (on gère manuellement la hauteur)
        rb.isKinematic = true; // Empêcher les forces physiques d’affecter la capsule

        cameraTransform = Camera.main?.transform;

        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, inputDevices);

        if (inputDevices.Count > 0)
        {
            controller = inputDevices[0];
        }
        else
        {
            Debug.LogError("Aucun contrôleur détecté !");
        }
    }

    void FixedUpdate()
    {
        AdjustHeightToGround(); // Détection du sol exécutée à chaque frame physique
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

                // Déplacement horizontal uniquement (X, Z)
                Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

                // **Appliquer la détection du sol AVANT de déplacer la capsule**
                newPosition.y = GetGroundHeight(newPosition);

                // Déplacer la capsule
                transform.position = newPosition;
            }
        }
    }

    void AdjustHeightToGround()
    {
        // Ajuster la hauteur même si le joueur ne bouge pas (ex: montée d'ascenseur)
        Vector3 currentPosition = transform.position;
        currentPosition.y = GetGroundHeight(currentPosition);
        transform.position = currentPosition;
    }

    private float GetGroundHeight(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position + Vector3.up * groundDetectionDistance, Vector3.down, out hit, groundDetectionDistance * 2, groundLayer))
        {
            return hit.point.y; // Retourne la hauteur du sol détecté
        }
        return transform.position.y; // Si aucun sol détecté, garde la hauteur actuelle
    }
}