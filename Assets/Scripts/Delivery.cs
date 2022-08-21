using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasItem = false;

    [SerializeField]
    private float destroyDelay = 0.5f;

     [SerializeField]
    private Color32 playerColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer playerSprite;

    private void Start() {
        playerSprite = GetComponent<SpriteRenderer>();    
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // If player collides with Item and doesnt have item, pick up item
        if (other.tag =="Item" && !hasItem) {
            hasItem = true;
            // Update color of player to color of item
            playerSprite.color = other.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject, destroyDelay);
        }

        // If player collides with NPC and has item, give item to NPC
        if (other.tag == "NPC" && hasItem) {   
            hasItem = false;
            playerSprite.color = playerColor;
        }
    }
}
