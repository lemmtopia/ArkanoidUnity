using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        // Get my Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Choose random X and Y sides
        int xSide = Random.Range(-1, 1);
        int ySide = Random.Range(-1, 1);

        // Default both sides to 1 if they are 0.
        xSide = (xSide == 0) ? 1 : xSide;
        ySide = (ySide == 0) ? 1 : ySide;

        // Create direciton vector
        Vector2 direction = new Vector2(xSide, ySide).normalized;

        // Set velocity vector
        rb.linearVelocity = direction * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
