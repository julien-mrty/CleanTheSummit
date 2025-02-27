﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class HighlightOnHover : MonoBehaviour
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
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }

        if (playerTransform == null && Camera.main != null)
        {
            playerTransform = Camera.main.transform;
        }
    }

    public void OnHoverEntered(XRBaseInteractor interactor)
    {
        if (objectRenderer == null || playerTransform == null) return;

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
        if (objectRenderer == null) return;
        objectRenderer.material.color = originalColor;
    }

    public void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (playerTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= grabDistance)
        {
            grabbedObjectsCount++;
            Debug.Log($"Objects grabbed: {grabbedObjectsCount}");
            gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<Console>().AddLine("Grab attempted but user is too far.");
        }
    }
}
