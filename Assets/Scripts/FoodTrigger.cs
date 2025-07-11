using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    public Counter counter;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<Counter>();
       

    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Turtle"))
        {
            audioManager.PlaySFX(audioManager.pickUp);
            
            Destroy(gameObject);

            counter.addCounter();

        }

    }










}
