using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float startDelayMax = 1f;
    [SerializeField] private float yBorder;

    private float startDelay = 0;
    private bool isMoving = false;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    void Start()
    {
        // Get my Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Set start position, delay and will not move
        startPosition = transform.position;
        rb.linearVelocity = Vector2.zero;
        startDelay = startDelayMax;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        startDelay -= Time.deltaTime;
        if (startDelay <= 0 && !isMoving)
        {
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

            // Prevent this code from running again
            isMoving = true;
        }

        if (transform.position.y <= -yBorder || Input.GetKeyDown(KeyCode.R))
        {
            // Reset
            transform.position = startPosition;
            rb.position = new Vector2(startPosition.x, startPosition.y);
            rb.linearVelocity = Vector2.zero;
            startDelay = startDelayMax;
            isMoving = false;

            Debug.Log(startDelay);
        }
    }
}
