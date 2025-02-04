using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public string acceptedTrashType; // Le type de déchet accepté (ex : "Pizza", "Pomme")

    void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet a le script TrashItem
        TrashItem trash = other.GetComponent<TrashItem>();

        if (trash != null)
        {
            // Vérifier si le type correspond
            if (trash.trashType == acceptedTrashType)
            {
                Debug.Log("Objet trié correctement : " + trash.trashType);
                Destroy(other.gameObject); // Détruire l'objet (le faire disparaître)
            }
            else
            {
                Debug.Log("Mauvaise poubelle pour : " + trash.trashType);
                // Tu peux ajouter un effet d'erreur ici
            }
        }
    }
}