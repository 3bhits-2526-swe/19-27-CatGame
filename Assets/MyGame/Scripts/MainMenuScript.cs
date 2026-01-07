using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Resetting score");
        ScoreManager.Instance.ResetScore();

        Debug.Log("Loading Game-Scene");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        ScoreManager.Instance.AddPoint();
        Application.Quit();
    }
}
