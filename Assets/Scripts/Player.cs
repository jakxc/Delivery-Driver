using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float steerSpeed = 300.0f;
    
     [SerializeField]
    private float moveSpeed = 20.0f;

    // Minimum speed of player
    [SerializeField]
    private float minSpeed = 10.0f;
   
    // Maximum of player
    [SerializeField]
    private float maxSpeed = 80.0f;
     
    [SerializeField]
    private float boostValue = 10.0f;

    [SerializeField]
    private float slowValue = 2.0f;

    // Update is called once per frame
    void Update()
    {   
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; 
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0,moveAmount,0);
        transform.Rotate(0, 0, -steerAmount);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (moveSpeed > minSpeed) {
            moveSpeed -= slowValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost" && moveSpeed < maxSpeed) {
            moveSpeed += boostValue;

            // Destroy the boost up
            Destroy(other.gameObject);
        }
    }
}
