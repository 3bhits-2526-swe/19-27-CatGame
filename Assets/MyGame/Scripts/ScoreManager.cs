using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    private TextMeshProUGUI scoreField;
    private TextMeshProUGUI highScoreField;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    // Each scene calls this when its UI is ready
    public void RegisterUI(TextMeshProUGUI score, TextMeshProUGUI highScore)
    {
        scoreField = score;
        highScoreField = highScore;

        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddPoint(int amount = 1)
    {
        CurrentScore += amount;

        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            SaveHighScore();
        }

        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreField != null)
            scoreField.text = "Score: " + CurrentScore;
    }

    private void UpdateHighScoreText()
    {
        if (highScoreField != null)
            highScoreField.text = "High Score: " + HighScore;
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
