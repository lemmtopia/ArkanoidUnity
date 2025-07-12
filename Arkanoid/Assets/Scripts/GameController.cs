using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Singleton Pattern: Only one instance of this script can exist as one time.
    // Access this script via GameController.Instance
    // Anyone can read from it, but only it can modify itself.
    public static GameController Instance { get; private set; }

    [SerializeField] private Text scoreText;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBricks();
        }
    }

    public void ResetBricks()
    {
        BrickController[] bricks = GameObject.FindObjectsByType<BrickController>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (BrickController brick in bricks)
        {
            brick.Respawn();
        }
    }

    public void ResetGame()
    {
        // Reset lives and score
        lives = livesStart;
        scoreToNextLifeRemaining = 0;
        score = 0;
    }

    // SetScore(int score): Sets score and updates the score text
    public void SetScore(int score)
    {
        this.score = score;

        scoreText.text = this.score.ToString();
    }

    // GetScore(): Gets score
    public int GetScore()
    {
        return score;
    }

    // AddScore(int score): Adds to score and updates the score text
    public void AddScore(int scoreAdd)
    {
        SetScore(score + scoreAdd);
    }
}
