using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float totalTime = 60f;       // Durée du timer en secondes
    public TextMeshProUGUI timeText;

    private float timeLeft;

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
        // Par exemple, on arrondit à l'entier avec .ToString("0")
        timeText.text = "Time: " + timeLeft.ToString("0");
    }
}
