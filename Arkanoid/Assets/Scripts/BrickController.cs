using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] Sprite[] breakingSprites;
    [SerializeField] int health = 1;

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
            // Destroy myself
            Destroy(this.gameObject);
        } 
    }
}
