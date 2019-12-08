using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad()); 
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetScore();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game Over");
    }
}

