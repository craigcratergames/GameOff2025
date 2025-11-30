using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;

    private void Start()
    {
        UpdateScoreDisplay();
    }

    public void IncreaseScore(int amount)
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(amount);
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        if (ScoreManager.Instance != null && scoreboardText != null)
        {
            scoreboardText.text = ScoreManager.Instance.CurrentScore.ToString();
        }
    }
}