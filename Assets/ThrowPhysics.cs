using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    public float throwForce = 5f; // Force horizontale
    public float upwardForce = 2f; // Force verticale

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Détection du relâchement de l'objet
        grabInteractable.onSelectExit.AddListener(OnRelease);
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        if (rb != null)
        {
            // Calcul de la direction avec une composante verticale
            Vector3 direction = interactor.transform.forward + Vector3.up * 0.3f;
            rb.velocity = direction.normalized * throwForce + Vector3.up * upwardForce;

            // Empêcher des rotations excessives
            rb.angularVelocity = Vector3.zero;

            // Debug de la trajectoire
            Debug.DrawRay(transform.position, rb.velocity, Color.red, 2f);
        }
    }
}