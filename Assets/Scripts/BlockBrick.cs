using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBrick : MonoBehaviour
{
    [SerializeField] AudioClip breakSFX;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBrick();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSFX, Camera.main.transform.position, .08f);
        level.RemoveBrick();
        Destroy(gameObject);
    }
}
