using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] Sprite[] breakingSprites;
    [SerializeField] int health = 1;
    [SerializeField] int points = 50;

    private int breakingSpriteIndex;

    void Start()
    {
        // Set to first sprite
        breakingSpriteIndex = 0;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (breakingSpriteIndex < breakingSprites.Length - 1)
        {
            // Add level
            breakingSpriteIndex++;

            // Breaking levels
            GetComponent<SpriteRenderer>().sprite = breakingSprites[breakingSpriteIndex];
        }

        health--;
        if (health <= 0)
        {
            // Add to GameController score
            GameController.Instance.AddScore(points);

            // Deactivate myself, not destroy
            gameObject.SetActive(false);
        } 
    }
}
