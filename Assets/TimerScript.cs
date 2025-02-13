using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float totalTime = 60f;       // Durée du timer en secondes
    public TextMeshProUGUI timeText;

    private float timeLeft;
    private bool timerEnded = false; // Vérification pour ne jouer le son qu'une seule fois

    public AudioSource audioSource;  // Ajout de l'AudioSource
    public AudioClip endSound;       // Son à jouer quand le timer est terminé

    void Start()
    {
        // Initialiser le compteur
        timeLeft = totalTime;
    }

    void Update()
    {
        // Réduire le temps restant en fonction du temps écoulé
        timeLeft -= Time.deltaTime;

        // Bloquer pour éviter d'afficher un temps négatif
        if (timeLeft < 0f)
            timeLeft = 0f;

        // Mettre à jour l'affichage
        timeText.text = "Time: " + timeLeft.ToString("0");

        // Vérifier si le temps est écoulé et jouer le son une seule fois
        if (timeLeft <= 0f && !timerEnded)
        {
            timerEnded = true;
            PlayEndSound();
        }
    }

    private void PlayEndSound()
    {
        if (audioSource != null && endSound != null)
        {
            audioSource.PlayOneShot(endSound);
        }
        else
        {
            Debug.LogWarning("Aucun son assigné pour la fin du timer !");
        }
    }
}
