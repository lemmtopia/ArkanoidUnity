using UnityEngine;

public class GameController : MonoBehaviour
{
    // Singleton Pattern: Only one instance of this script can exist as one time.
    // Access this script via GameController.Instance
    // Anyone can read from it, but only it can modify itself.
    public static GameController Instance { get; private set; }

    // Lives and score
    public int livesMax = 9;
    public int livesStart = 3;
    public int lives = 0;

    public int scoreToNextLifeTarget = 1000;
    public int scoreToNextLifeRemaining = 0;    // Resets when hits scoreToNextLifeTarget and gets a life.

    public int score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        
    }

    public void ResetBricks()
    {

    }

    public void ResetGame()
    {
        // Reset lives and score
        lives = livesStart;
        scoreToNextLifeRemaining = 0;
        score = 0;
    }
}
