using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gameStatus;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameStatus = FindObjectOfType<GameSession>();
        scoreText.text = gameStatus.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameStatus.GetScore().ToString();
    }
}
