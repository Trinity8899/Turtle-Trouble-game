using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Turtle : MonoBehaviour
{

    public Rigidbody2D turtle;
    public int turtleSpeed = 2;
    public Counter counter;
    public bool turtleIsAlive = true;
    public Animator turtleAnimator;
    public float turtleHigh = 8.2f;
    public float turtleLow = -7.9f;
    
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }



    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<Counter>();

    }


    // Move turtle up on Space key press if alive.
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && turtleIsAlive)
        {

            turtle.velocity = Vector2.up * turtleSpeed;

        }
        // Turtle position.
        Vector3 pos = turtle.transform.position;
        {
            if (pos.y > turtleHigh) pos.y = turtleHigh;
            if (pos.y < turtleLow) pos.y = turtleLow;

            turtle.transform.position = pos;

        }

        if (!turtleIsAlive)
        {
            return; // No other code should execute.
        }


    }

    // Handle collision: play game over sound, trigger game over, kill turtle, stop music.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlaySFX(audioManager.gameOver);
        counter.gameOver();
        turtleIsAlive = false;
        turtle.gravityScale = 4f;
        turtleAnimator.enabled = false;
        audioManager.StopMusic();

    }

   
}
