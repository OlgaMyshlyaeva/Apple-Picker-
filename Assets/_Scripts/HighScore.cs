using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
    private Text scoreText;

    void Awake()
    {
        // Cache the Text component to avoid calling GetComponent in Update
        scoreText = this.GetComponent<Text>();

        // Load existing HighScore from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        
        // Ensure the HighScore is initialized in PlayerPrefs
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update()
    {
        // Update the UI text with the current high score
        if (scoreText != null)
        {
            scoreText.text = "High Score: " + score;
        }

        // Update PlayerPrefs if the current score exceeds the saved record
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

