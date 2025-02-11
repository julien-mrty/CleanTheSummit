using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public string acceptedTrashType; // Le type de d�chet accept� (ex : "Pizza", "Pomme")
    public ParticleSystem successParticles; // R�f�rence au syst�me de particules

    void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'objet entrant a un script TrashItem
        TrashItem trash = other.GetComponent<TrashItem>();

        if (trash != null)
        {
            // V�rifier si le type correspond
            if (trash.trashType == acceptedTrashType)
            {
                Debug.Log("Objet tri� correctement : " + trash.trashType);
                Destroy(other.gameObject); // D�truire l'objet
            }
            else
            {
                Debug.Log("Mauvaise poubelle pour : " + trash.trashType);
                // Tu peux ajouter un effet d'erreur ici (par exemple, un son ou un message visuel)
            }
        }
    }
}