using UnityEngine;
using Unity.XR.PXR;

public class ControllerRaycaster : MonoBehaviour
{
    [Header("Raycast Settings")]
    [Tooltip("How far the controller can interact.")]
    public float raycastDistance = 20f;

    [Tooltip("Distance threshold within which clicking will make the object disappear.")]
    public float interactionDistanceThreshold = 3f;

    [Header("References")]
    [Tooltip("The transform from which the ray is cast; usually the controller itself.")]
    public Transform rayOrigin;

    [Tooltip("Layermask for objects you want to interact with.")]
    public LayerMask interactableLayer;

    void Update()
    {
        // 1) Create the Ray
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hitInfo;

        // 2) Raycast forward from the controller
        if (Physics.Raycast(ray, out hitInfo, raycastDistance, interactableLayer))
        {
            // You can do something like show a highlight on the pointed object here if you want.

            // 3) When the user clicks the trigger or button on Pico G2
            //if (PXR_Controller.GetKeyDown(PXR_Controller.Controller.LHand, PXR_Controller.Button.Trigger))
            //{
                // 4) Check the distance between the user (headset/camera) and the object
                float distance = Vector3.Distance(Camera.main.transform.position, hitInfo.transform.position);

                if (distance <= interactionDistanceThreshold)
                {
                    // 5) If close enough, hide or remove the object
                    // For example, you can just destroy it:
                    Destroy(hitInfo.transform.gameObject);

                    // or set it inactive:
                    // hitInfo.transform.gameObject.SetActive(false);
                }
                else
                {
                    // Too far, do nothing
                }
            //}
        }
        else
        {
            // If nothing is hit, you can hide any pointer or highlight here
        }
    }
}
