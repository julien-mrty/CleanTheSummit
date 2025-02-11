using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrashGrab : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Désactiver la physique au départ
        rb.isKinematic = true;

        // Ajout des événements manuellement pour Unity 2020
        grabInteractable.onSelectEnter.AddListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Activer la gravité et la physique
        rb.isKinematic = false;
    }
}
