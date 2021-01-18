using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBrick : MonoBehaviour
{
    // Config Params
    [SerializeField] AudioClip breakSFX;
    [SerializeField] GameObject blockParticlesVfx;
    [SerializeField] int hitPoints;
    [SerializeField] Sprite[] sprites;

    // Cached refs
    Level level;
    GameStatus gameStatus;
    SpriteRenderer spriteRenderer;

    // State
    [SerializeField] int timesHit;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (tag == "Breakable") { level.CountBrick(); }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        
        if (tag == "Breakable")
        {
            AudioSource.PlayClipAtPoint(breakSFX, Camera.main.transform.position, .08f);
            if( timesHit >= hitPoints)
            {
                DestroyBrick();
            }
            else
            {
                ShowNextSprite();
            }
            
        }
        
    }

    private void DestroyBrick()
    {
        triggerParticlesVfx();
        level.RemoveBrick();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }

    private void ShowNextSprite()
    {
        spriteRenderer.sprite = sprites[timesHit];
    }
    private void triggerParticlesVfx()
    {
        GameObject particles = Instantiate(blockParticlesVfx, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }
}
