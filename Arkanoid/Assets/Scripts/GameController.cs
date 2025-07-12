using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Singleton Pattern: Only one instance of this script can exist as one time.
    // Access this script via GameController.Instance
    // Anyone can read from it, but only it can modify itself.
    public static GameController Instance { get; private set; }

    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;

    // Lives and score
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

    private void Start()
    {
        SetLives(livesStart);
        SetScore(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void ResetBricks()
    {
        // Get all BrickControllers in all bricks (including inactive ones)
        BrickController[] bricks = GameObject.FindObjectsByType<BrickController>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        // Loop
        foreach (BrickController brick in bricks)
        {
            // Respawn brick
            brick.Respawn();
        }
    }

    public void ResetGame()
    {
        // Reset lives and score
        lives = livesStart;
        scoreToNextLifeRemaining = 0;
        score = 0;

        // Reset bricks
        ResetBricks();
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

    // SetLives(int lives): Sets score and updates the lives text
    public void SetLives(int lives)
    {
        this.lives = lives;

        livesText.text = this.lives.ToString();
    }

    // Getlives(): Gets lives
    public int GetLives()
    {
        return lives;
    }

    // AddLives(int lives): Adds to lives and updates the lives text
    public void AddLives(int livesAdd)
    {
        SetLives(lives + livesAdd);

        // add to remaining score to next life
        scoreToNextLifeRemaining += livesAdd;

        if (scoreToNextLifeRemaining >= scoreToNextLifeTarget)
        {
            // Add a new life and reset remaining score
            AddLives(1);
            scoreToNextLifeRemaining = 0;
        }
    }
}
