using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Tree Movement Settings")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    
    [Header("Spawning Settings")]
    public float secondsBetweenAppleDrops = 1f;
    
    void Start()
    {
        // Start dropping apples after a 2-second delay
        Invoke("DropApple", 2f);
    }
    
    void DropApple()
    {
        // Instantiate an apple and schedule the next drop
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    
    void Update()
    {
        // Basic movement: move the tree per frame
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Change direction when reaching screen edges
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate()
    {
        // Randomly change direction based on a probability threshold
        // FixedUpdate is used here to decouple probability checks from frame rate
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
