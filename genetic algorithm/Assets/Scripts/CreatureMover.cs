using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    public float maxSpeed = 3f; // The maxium speed an alien can reach
    public float accelerationTime = 2f;
    private Rigidbody2D rigidBody;
    private float timeBetweenChangeDirection;
    private Vector2 movement;
 
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Will set a new direction for the alien to walk in every frame
        timeBetweenChangeDirection -= Time.deltaTime;
        if(timeBetweenChangeDirection <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeBetweenChangeDirection += accelerationTime;
        }
    }

    // If the alien collides with something then walk in the opposite direction
    void OnCollissionEnter2D(Collision2D col)
    {
        movement = -movement;
    }

    // Make the alien walk
    void FixedUpdate()
    {
        rigidBody.AddForce(movement * maxSpeed);
    }
}
