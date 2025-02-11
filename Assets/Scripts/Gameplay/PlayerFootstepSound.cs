using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerFootstepSound : MonoBehaviour
{
    public AudioSource footstepAudio;
    public float stepInterval = 0.5f;  // Temps entre chaque pas
    private float stepTimer = 0f;
    
    private InputDevice controller;
    private bool isMoving = false;

    void Start()
    {
        if (footstepAudio == null)
        {
            Debug.LogError("[FootstepSound] Aucun AudioSource assigné !");
        }

        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, inputDevices);

        if (inputDevices.Count > 0)
        {
            controller = inputDevices[0];
            Debug.Log("[FootstepSound] Contrôleur détecté !");
        }
        else
        {
            Debug.LogError("[FootstepSound] Aucun contrôleur valide détecté !");
        }
    }

    void Update()
    {
        if (controller.isValid && footstepAudio != null)
        {
            if (controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 touchpadValue))
            {
                if (touchpadValue.magnitude > 0.1f) // Vérifie si le joueur bouge
                {
                    if (!isMoving)
                    {
                        Debug.Log("[FootstepSound] Début du mouvement");
                        isMoving = true;
                    }

                    stepTimer += Time.deltaTime;
                    if (stepTimer >= stepInterval)
                    {
                        if (!footstepAudio.isPlaying)
                        {
                            Debug.Log("[FootstepSound] Joue un son de pas");
                            footstepAudio.Play();
                        }
                        stepTimer = 0f;
                    }
                }
                else
                {
                    if (isMoving)
                    {
                        Debug.Log("[FootstepSound] Arrêt du mouvement, son stoppé");
                        footstepAudio.Stop(); // Stoppe immédiatement le son
                        stepTimer = 0f;
                        isMoving = false;
                    }
                }
            }
        }
    }
}
