using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float totalTime = 60f;       // Dur�e du timer en secondes
    public TextMeshProUGUI timeText;

    private float timeLeft;

    void Start()
    {
        // Initialiser le compteur
        timeLeft = totalTime;
    }

    void Update()
    {
        // R�duire le temps restant en fonction du temps �coul�
        timeLeft -= Time.deltaTime;

        // Bloquer pour �viter d'afficher un temps n�gatif
        if (timeLeft < 0f)
            timeLeft = 0f;

        // Mettre � jour l'affichage
        // Par exemple, on arrondit � l'entier avec .ToString("0")
        timeText.text = "Time: " + timeLeft.ToString("0");
    }
}
