using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        healthText.text = playerHealth.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerKO()
    {
        if (playerHealth > 1)
        {
            TakeDamage();
        }
        else
        {
            ResetGameSession();
        }
        
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    private void TakeDamage()
    {
        playerHealth--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        healthText.text = playerHealth.ToString();

    }

    void ResetGameSession()
    {
        FindObjectOfType<LevelPersist>().ResetLevelPersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
