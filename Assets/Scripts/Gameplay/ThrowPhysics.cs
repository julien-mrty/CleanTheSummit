using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    public float throwForce = 5f;  // Force horizontale
    public float upwardForce = 2f; // Force verticale

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.onSelectExit.AddListener(OnRelease);
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        if (rb == null) return;

        Transform attachTransform = null;

        XRDirectInteractor directInteractor = interactor as XRDirectInteractor;
        if (directInteractor != null)
        {
            attachTransform = directInteractor.attachTransform;
        }
        else
        {
            XRRayInteractor rayInteractor = interactor as XRRayInteractor;
            if (rayInteractor != null)
                attachTransform = rayInteractor.attachTransform;
        }

        if (attachTransform == null)
            attachTransform = interactor.transform;

        Vector3 direction = attachTransform.forward + Vector3.up * 0.3f;

        rb.velocity = direction.normalized * throwForce + Vector3.up * upwardForce;

        // Empêcher les rotations excessives
        rb.angularVelocity = Vector3.zero;

        // Debug
        Debug.DrawRay(transform.position, rb.velocity, Color.red, 2f);
    }
}
