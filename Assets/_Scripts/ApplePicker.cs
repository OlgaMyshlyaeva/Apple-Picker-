using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Baskets Setup")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    
    [Header("Game State")]
    public int score = 0;

    void Start()
    {
        // Initialize the basket list and spawn baskets at the start of the game
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    /// <summary>
    /// Handles the logic when an apple is missed by the player.
    /// </summary>
    public void AppleMissed()
    {
        // Find and destroy all existing apples on the screen
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Remove the last basket from the list and destroy its GameObject
        if (basketList.Count > 0)
        {
            int basketIndex = basketList.Count - 1;
            GameObject tBasketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);
        }

        // If no baskets left, save the score and trigger Game Over
        if (basketList.Count == 0)
        {
            PlayerPrefs.SetInt("CurrentScore", score);
            PlayerPrefs.Save();

            SceneManager.LoadScene("GameOverScene");
        }
    }

    /// <summary>
    /// Updates the score when an apple is caught.
    /// </summary>
    public void AddToScore(int points)
    {
        score += points;
    }
}
