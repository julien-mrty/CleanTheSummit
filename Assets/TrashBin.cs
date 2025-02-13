using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public string acceptedTrashType; // Type de déchet accepté (ex: "Pizza", "Pomme")
    public ParticleSystem successParticles; // Particules en cas de succès

    public AudioSource audioSource; // Source audio
    public AudioClip successSound; // Son pour un tri réussi
    public AudioClip failureSound; // Son pour un échec

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        TrashItem trash = other.GetComponent<TrashItem>();

        if (trash != null)
        {
            if (trash.trashType == acceptedTrashType)
            {
                Debug.Log("Objet trié correctement : " + trash.trashType);
                ScoreManager.Instance.AddScore(1);

                // Jouer le son de succès
                PlaySuccessSound();

                // Déclencher les particules si disponibles
                if (successParticles != null)
                    successParticles.Play();

                Destroy(other.gameObject); // Détruire l'objet
            }
            else
            {
                Debug.Log("Mauvaise poubelle pour : " + trash.trashType);

                // Jouer le son d’échec
                PlayFailureSound();
            }
        }
    }

    private void PlaySuccessSound()
    {
        if (audioSource != null && successSound != null)
        {
            audioSource.PlayOneShot(successSound);
        }
    }

    private void PlayFailureSound()
    {
        if (audioSource != null && failureSound != null)
        {
            audioSource.PlayOneShot(failureSound);
        }
    }
}
