using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    /// <summary>
    /// Loads the main game scene. 
    /// This method is designed to be called via Unity UI Button onClick event.
    /// </summary>
    public void LoadGame()
    {
        // Replace "_Scene_0" with your actual game scene name if needed
        SceneManager.LoadScene("_Scene_0");
    }

    /// <summary>
    /// Resets all saved high scores and player progress.
    /// Use this for a "Reset Progress" button in the menu.
    /// </summary>
    public void ResetProgress()
    {
        // Delete specific keys used in the game
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("Record");
        PlayerPrefs.DeleteKey("CurrentScore");
        
        // Force save changes to disk
        PlayerPrefs.Save();
        
        Debug.Log("Game progress has been reset.");
        
        // Optional: Reload the scene to refresh UI text if needed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
