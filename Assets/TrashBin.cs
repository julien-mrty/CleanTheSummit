using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public string acceptedTrashType; // Le type de d�chet accept� (ex : "Pizza", "Pomme")

    void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'objet a le script TrashItem
        TrashItem trash = other.GetComponent<TrashItem>();

        if (trash != null)
        {
            // V�rifier si le type correspond
            if (trash.trashType == acceptedTrashType)
            {
                Debug.Log("Objet tri� correctement : " + trash.trashType);
                Destroy(other.gameObject); // D�truire l'objet (le faire dispara�tre)
            }
            else
            {
                Debug.Log("Mauvaise poubelle pour : " + trash.trashType);
                // Tu peux ajouter un effet d'erreur ici
            }
        }
    }
}