using UnityEngine;
using TMPro;  
using UnityEngine.InputSystem;

public class Basket : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI scoreGT;
    
    private ApplePicker applePicker;

    void Start()
    {
        // Find the ScoreCounter object and get its TextMeshPro component
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        }

        // Cache the reference to the ApplePicker game manager
        applePicker = Object.FindFirstObjectByType<ApplePicker>();
        if (applePicker == null)
        {
            Debug.LogError("ApplePicker manager not found in the scene!");
        }

        // Initialize score display
        if (scoreGT != null)
        {
            scoreGT.text = "0";
        }
    }

    void Update()
    {
        if (Camera.main != null)
        {
            // Convert mouse screen position to world coordinates
            Vector2 mouseScreen = Mouse.current.position.ReadValue();
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                mouseScreen.x, 
                mouseScreen.y, 
                -Camera.main.transform.position.z));
            
            // Move the basket horizontally based on the mouse position
            Vector3 pos = transform.position;
            pos.x = mouseWorld.x;
            transform.position = pos;

            // Sync the UI score text with the manager's score
            if (scoreGT != null && applePicker != null)
            {
                scoreGT.text = applePicker.score.ToString();
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        // Check if the collided object is an apple
        if (coll.gameObject.CompareTag("Apple"))
        {
            // Notify manager to add points and destroy the apple
            applePicker.AddToScore(100); 
            Destroy(coll.gameObject);
        }
    }
}
