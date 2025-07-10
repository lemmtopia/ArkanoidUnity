using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] bool isYellow = false;
    [SerializeField] Sprite yellowCrackedSprite;
    [SerializeField] int health = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isYellow)
        {
            GetComponent<SpriteRenderer>().sprite = yellowCrackedSprite;
        }

        health--;
        if (health <= 0)
        {
            // Destroy myself
            Destroy(this.gameObject);
        } 
    }
}
