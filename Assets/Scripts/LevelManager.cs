using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        // Reset score when starting a new game
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}