using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int currentScore = 0;

    public int CurrentScore 
    { 
        get { return currentScore; }
        private set { currentScore = value; }
    }

    private void Awake()
    {
        // Singleton pattern - only one instance should exist
        if (Instance == null)
        {
            Instance = this;
            // Ensure this GameObject is at root level before calling DontDestroyOnLoad
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public int GetFinalScore()
    {
        return currentScore;
    }
}