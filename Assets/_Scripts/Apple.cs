using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Movement Settings")]
    public static float bottomY = -20f; // Boundary after which the apple is destroyed

    void Update()
    {
        // Check if the apple has fallen below the game world boundary
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Reference the main camera to notify the game manager of a missed apple
            ApplePicker ap = Camera.main.GetComponent<ApplePicker>();
            if (ap != null)
            {
                ap.AppleMissed();
            }
        }
    }
}
