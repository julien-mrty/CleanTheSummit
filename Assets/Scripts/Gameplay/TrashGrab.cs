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

        // D�sactiver la physique au d�part
        rb.isKinematic = true;

        // Ajout des �v�nements manuellement pour Unity 2020
        grabInteractable.onSelectEnter.AddListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Activer la gravit� et la physique
        rb.isKinematic = false;
    }
}
