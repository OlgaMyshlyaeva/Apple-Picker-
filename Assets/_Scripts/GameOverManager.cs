using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverCanvas;
    public TMP_Text scoreText;
    public TMP_Text recordText;

    void Start()
    {
        // Check if all UI references are assigned in the Inspector
        if (gameOverCanvas == null || scoreText == null || recordText == null)
        {
            Debug.LogError("UI references are missing in GameOverManager!");
            return;
        }

        // Retrieve the score from the last game session
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        
        // Update and display the results
        ShowGameOver(currentScore);
    }

    /// <summary>
    /// Displays the final score and updates the high score if necessary.
    /// </summary>
    public void ShowGameOver(int currentScore)
    {
        gameOverCanvas.SetActive(true);
        scoreText.text = "Score: " + currentScore;

        // Manage high score using PlayerPrefs
        int record = PlayerPrefs.GetInt("Record", 0);
        if (currentScore > record)
        {
            record = currentScore;
            PlayerPrefs.SetInt("Record", record);
            PlayerPrefs.Save(); // Ensure the record is written to disk
        }

        recordText.text = "Record: " + record;
    }

    /// <summary>
    /// Reloads the main game scene.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}



