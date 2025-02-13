using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class HighlightOnHoverPrefab : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    public Color proximityHighlightColor = Color.green;
    public float grabDistance = 1.0f;
    public Transform playerTransform;

    private Renderer objectRenderer;
    private Color originalColor;
    private static int grabbedObjectsCount = 0;

    private void Awake()
    {
        // 1. On cherche le Renderer dans l'objet courant OU dans ses enfants.
        objectRenderer = GetComponentInChildren<Renderer>();
        if (objectRenderer != null)
        {
            // 2. On �vite de modifier le sharedMaterial du prefab
            //    en cr�ant une instance unique du mat�riau dans la sc�ne.
            Material matInstance = new Material(objectRenderer.material);
            objectRenderer.material = matInstance;

            // 3. On stocke la couleur de base.
            originalColor = matInstance.color;
        }
        else
        {
            Debug.LogWarning($"[{name}] Aucun Renderer trouv� dans {gameObject.name} ou ses enfants.");
        }

        // 4. Si on n'a pas d�fini de playerTransform, on le r�cup�re depuis la Main Camera (VR).
        if (playerTransform == null && Camera.main != null)
        {
            playerTransform = Camera.main.transform;
        }
    }

    public void OnHoverEntered(XRBaseInteractor interactor)
    {
        if (objectRenderer == null || playerTransform == null)
        {
            return;
        }

        // V�rification de la distance
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= grabDistance)
        {
            objectRenderer.material.color = proximityHighlightColor;
        }
        else
        {
            objectRenderer.material.color = highlightColor;
        }
    }

    public void OnHoverExited(XRBaseInteractor interactor)
    {
        if (objectRenderer == null)
        {
            return;
        }
        objectRenderer.material.color = originalColor;
    }

    public void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (playerTransform == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= grabDistance)
        {
            grabbedObjectsCount++;
            Debug.Log($"Objects grabbed: {grabbedObjectsCount}");

            // On d�sactive l'objet pour simuler le 'grab'
            gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<Console>()?.AddLine("Grab attempted but user is too far.");
        }
    }
}