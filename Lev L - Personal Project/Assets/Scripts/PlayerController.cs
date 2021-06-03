using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private float topBound = 6.5f;
    private float speed = 10;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();        
    }

    // Moves the player based on arrow key input 
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
    }

    // Prevents the player from leaving the top or bottom of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > topBound) { transform.position = new Vector3(transform.position.x, transform.position.y, topBound); }
        if (transform.position.z < -topBound) { transform.position = new Vector3(transform.position.x, transform.position.y, -topBound); }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy")) 
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
