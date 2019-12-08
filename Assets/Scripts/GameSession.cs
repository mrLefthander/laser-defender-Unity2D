using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField][Range(0.1f, 10f)] float gameSpeed = 1f;
    [SerializeField][Range(0,1)] float gameVolume = 1f;

    int currentScore = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void AddToScore(int scoreValue)
    {
        currentScore += scoreValue;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public float GameVolume { get => gameVolume; set => gameVolume = value; }
}
