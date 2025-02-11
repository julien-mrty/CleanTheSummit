using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    private void Awake()
    {
        // Si une instance existe d�j�, on d�truit le duplicat
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // Sinon on d�finit l�instance
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}