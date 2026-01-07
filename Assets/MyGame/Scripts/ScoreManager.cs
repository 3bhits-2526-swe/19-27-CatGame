using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    [SerializeField] private TextMeshProUGUI Score_Field;

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
        UpdateScoreText();
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
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (Score_Field != null)
        {
            Score_Field.text = "Score: " + CurrentScore;
        }
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
