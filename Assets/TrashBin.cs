using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public string acceptedTrashType; // Le type de déchet accepté (ex : "Pizza", "Pomme")
    public ParticleSystem successParticles; // Référence au système de particules

    void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet entrant a un script TrashItem
        TrashItem trash = other.GetComponent<TrashItem>();

        if (trash != null)
        {
            // Vérifier si le type correspond
            if (trash.trashType == acceptedTrashType)
            {
                Debug.Log("Objet trié correctement : " + trash.trashType);
                Destroy(other.gameObject); // Détruire l'objet
            }
            else
            {
                Debug.Log("Mauvaise poubelle pour : " + trash.trashType);
                // Tu peux ajouter un effet d'erreur ici (par exemple, un son ou un message visuel)
            }
        }
    }
}