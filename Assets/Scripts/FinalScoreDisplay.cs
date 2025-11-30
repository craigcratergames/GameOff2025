using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text finalScoreText;

    private void Start()
    {
        DisplayFinalScore();
    }

    private void DisplayFinalScore()
    {
        if (ScoreManager.Instance != null && finalScoreText != null)
        {
            finalScoreText.text = ScoreManager.Instance.GetFinalScore().ToString();
        }
        else
        {
            finalScoreText.text = "0";
        }
    }
}