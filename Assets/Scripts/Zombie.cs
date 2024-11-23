using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField] private float xMax,xMin;
    [SerializeField] private float moveSpeed = 2f; 
    private Vector2 direction = Vector2.right;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (transform.position.x >= xMax)
        {
            direction = Vector2.left; 
            FlipSprite(true); 
        }
        else if (transform.position.x <= xMin)
        {
            direction = Vector2.right; 
            FlipSprite(false); 
        }
    }

    private void FlipSprite(bool facingLeft)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = facingLeft;
        }
    }
}


