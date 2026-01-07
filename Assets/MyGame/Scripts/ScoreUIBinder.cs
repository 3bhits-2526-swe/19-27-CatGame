using UnityEngine;
using TMPro;

public class ScoreUIBinder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreField;
    [SerializeField] private TextMeshProUGUI highScoreField;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.RegisterUI(scoreField, highScoreField);
        }
    }
}
